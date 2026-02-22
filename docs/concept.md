# Portfolio Project – Alpha

## Overview
This Project uses 2 or 3 APIs to get data from. The data is processed to show statistics, diagrams and a history 
of some data. This project has the purpose to show my tech skills. 

## Tech Stack
- **Backend:** ABP Framework, .NET 10, C#
- **Database:** PostgreSQL (Docker)
- **Background Jobs:** Hangfire
- **Containerization:** Docker, Kubernetes (local: Docker Desktop / minikube)
- **CI/CD:** GitHub Actions
- **Hosting:** Oracle Cloud Free Tier / Railway.app

---

# Details

## 1. Architecture
Brief description or diagram: How do the frontend, backend, database and external APIs communicate?

### UI

one UI for each Api data - to keep it structured

Soon to come

## 2. APIs
External APIs used – free tier, watch out for rate limits:
- Brightsky (weather data from DWD)
- NewsAPI (dev tier free)
- ExchangeRate-API
- The Movie DB

## 3. Database
- Official PostgreSQL Docker image
- Volume for data persistence
- Environment variables: POSTGRES_USER, POSTGRES_PASSWORD, POSTGRES_DB
- pgAdmin as a second container (optional, for GUI access)

## 4. Kubernetes Setup
- Local: Docker Desktop (built-in K8s) or minikube
- Reserve at least 4 GB RAM
- Services: ClusterIP (internal), LoadBalancer / Ingress (external)
- TLS: cert-manager + Let's Encrypt

## 5. ABP Project Structure
- Brief description of layers (Domain, Application, HttpApi, Web)
- Which ABP modules are used?

## 6. CI/CD Pipeline (GitHub Actions)
Stages:
1. Build
2. Test
3. Docker Build & Push (ghcr.io)
4. Deploy to Kubernetes

Secrets to store in GitHub:
- REGISTRY_PASSWORD
- DB_CONNECTION_STRING
- KUBECONFIG

## 7. Environments
| Environment | Purpose                      | K8s Namespace |
|-------------|------------------------------|---------------|
| Local       | Development on local machine | –             |
| Dev         | Feature testing              | dev           |
| Staging     | Pre-production testing       | staging       |
| Production  | Live system                  | production    |

Configuration via `appsettings.{Environment}.json` + environment variable `ASPNETCORE_ENVIRONMENT`

## 8. Authentication
- [ ] Which solution is used? (ABP Identity, JWT, OpenIddict?)
- [ ] Which roles exist?

## 9. Domain & Hosting
- DuckDNS (free) or affordable provider
- HTTPS via Let's Encrypt

## 10. Important Files
| File | Purpose |
|------|---------|
| `appsettings.json` | Base configuration (no secrets!) |
| `appsettings.{Env}.json` | Environment-specific values |
| `.editorconfig` | Code style rules |
| `.gitignore` | Excluded files |
| `Dockerfile` | Image definition |
| `docker-compose.yml` | Local multi-container setup |
| `k8s/*.yaml` | Kubernetes manifests |
| `.github/workflows/*.yml` | CI/CD pipeline definition |

## 11. Logging & Monitoring
- **Logs:** Serilog + Seq (running as container)
- **Metrics:** Prometheus + Grafana
- **Health Checks:** ABP built-in endpoints (`/health`)

## 12. Open Points / TODOs
- [ ] Obtain API keys
- [ ] Register domain
- [ ] Create K8s secrets
- [ ] Test pipeline
