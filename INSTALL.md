# Installing PeopleManager (Docker Compose)

These steps set up PeopleManager on a fresh Debian LXC container using
Docker Compose. The image is built **on the LXC itself** from source
pulled with `git` — nothing is published from Visual Studio.

The app is a private, single-user tool intended for a private LAN. These
steps do not set up HTTPS or a reverse proxy; add one yourself if you
ever expose it beyond your LAN.

## 1. Prerequisites

- **Docker Engine + the Compose plugin** must already be installed on the LXC
  (`docker --version` and `docker compose version` should both work). See
  [Docker's official Debian install instructions](https://docs.docker.com/engine/install/debian/)
  if you still need to set that up.
- **`git`**:

  ```bash
  sudo apt update
  sudo apt install -y git
  ```

(Optional) To run `docker` without `sudo`, make sure your user is in the
`docker` group (log out and back in after adding it):

```bash
sudo usermod -aG docker $USER
```

If you skip this, just prefix every `docker` command below with `sudo`.

## 2. Clone the repository

The `blazor` branch is the Blazor Server app (the `main` branch is a legacy
WinForms version — don't use it here).

```bash
cd /opt
sudo git clone https://github.com/imnorm69/PeopleManager.git
cd PeopleManager
sudo git checkout blazor
```

(Adjust ownership of `/opt/PeopleManager` to your user if you didn't add
yourself to the `docker` group and don't want to run everything as root —
`sudo chown -R $USER:$USER /opt/PeopleManager`.)

The repo already includes `Dockerfile`, `.dockerignore`, and
`docker-compose.yml` at its root — nothing to author yourself.

## 3. First build and start

From the repo root (`/opt/PeopleManager`):

```bash
docker compose up -d --build
```

This builds the image locally (SDK stage compiles + publishes the app,
runtime stage just runs it) and starts the container in the background.
On first start, the app automatically creates and migrates its SQLite
database inside the named Docker volume `peoplemanager-data` — no manual
DB setup step needed.

Check it's up:

```bash
docker compose ps
docker compose logs -f
```

Then browse to `http://<lxc-ip>:8080` from another machine on your LAN.
Press `Ctrl+C` to stop following logs (the container keeps running).

If you have `ufw` enabled on the LXC, allow the port:

```bash
sudo ufw allow 8080/tcp
```

## 4. Updating to a new version

Whenever you push changes to the `blazor` branch, redeploy with:

```bash
cd /opt/PeopleManager
git pull
docker compose up -d --build
```

`--build` rebuilds the image from the latest source; Compose then
recreates the container from the new image. The named volume
(`peoplemanager-data`) is untouched by this, so your data survives every
rebuild. Any pending EF Core migrations run automatically the next time
the container starts (see `Program.cs`'s `db.Database.MigrateAsync()`).

To confirm which commit the running image was built from, check what
was checked out on the host at the time of the last `--build` (Compose
doesn't stamp the image with this automatically):

```bash
git log -1 --oneline
```

## 5. Useful maintenance commands

Stop / start without rebuilding:

```bash
docker compose stop
docker compose start
```

Restart just the app (e.g. after manually editing environment variables in
`docker-compose.yml`):

```bash
docker compose up -d
```

Tail logs:

```bash
docker compose logs -f --tail=100
```

Open a shell inside the running container (for troubleshooting):

```bash
docker compose exec peoplemanager /bin/bash
```

## 6. Backing up your data

The SQLite database lives in the `peoplemanager-data` named volume, not on
the container filesystem, so it survives rebuilds/`docker compose down`
(without `-v`). To back it up:

```bash
docker run --rm -v peoplemanager-data:/data -v "$(pwd)":/backup debian:stable-slim \
  tar czf /backup/peoplemanager-data-backup.tar.gz -C /data .
```

This writes `peoplemanager-data-backup.tar.gz` into your current
directory. To restore it onto a fresh volume:

```bash
docker run --rm -v peoplemanager-data:/data -v "$(pwd)":/backup debian:stable-slim \
  tar xzf /backup/peoplemanager-data-backup.tar.gz -C /data
```

**Never run `docker compose down -v`** unless you intend to permanently
delete the database — the `-v` flag removes named volumes along with the
containers.

## 7. Full removal

```bash
docker compose down       # stops and removes the container, keeps the volume/data
docker compose down -v    # also deletes the peoplemanager-data volume — irreversible
```
