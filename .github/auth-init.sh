#!/bin/bash
projectId="awtor-sheduler"
projectNumber="530662206793"
githubOwner="franzzua"
githubProject="sheduler"
location="europe-west1"

gcloud iam service-accounts create "github-deploy" --project "$projectId"
gcloud iam workload-identity-pools create "github" --project="$projectId" --location="global" --display-name="GitHub Actions Pool"
gcloud iam workload-identity-pools describe "github" --project="$projectId" --location="global" --format="value(name)"

gcloud iam workload-identity-pools providers create-oidc "my-repo" \
  --project="$projectId"  \
  --location="global"  \
  --workload-identity-pool="github"  \
  --display-name="My GitHub repo Provider"  \
  --attribute-mapping="google.subject=assertion.sub,attribute.actor=assertion.actor,attribute.repository=assertion.repository,attribute.repository_owner=assertion.repository_owner"  \
  --attribute-condition="assertion.repository_owner == '$githubOwner'"  \
  --issuer-uri="https://token.actions.githubusercontent.com"
  
gcloud iam workload-identity-pools providers describe "my-repo" \
  --project="$projectId" \
  --location="global" \
  --workload-identity-pool="github" \
  --format="value(name)"
  
gcloud iam service-accounts add-iam-policy-binding "github-deploy@$projectId.iam.gserviceaccount.com" \
  --project="$projectId" \
  --role="roles/iam.workloadIdentityUser" \
  --member="principalSet://iam.googleapis.com/projects/$projectNumber/locations/global/workloadIdentityPools/github/attribute.repository/$githubOwner/$githubProject"
  
gcloud projects add-iam-policy-binding $projectId \
  --role="roles/artifactregistry.repoAdmin" \
  --member="serviceAccount:github-deploy@$projectId.iam.gserviceaccount.com"
  
gcloud projects add-iam-policy-binding $projectId \
  --role="roles/cloudfunctions.developer" \
  --member="serviceAccount:github-deploy@$projectId.iam.gserviceaccount.com"
  
gcloud projects add-iam-policy-binding $projectId \
  --role="roles/iam.serviceAccountTokenCreator" \
  --member="serviceAccount:github-deploy@$projectId.iam.gserviceaccount.com"

gcloud projects add-iam-policy-binding $projectId \
  --role="roles/run.admin" \
  --member="serviceAccount:github-deploy@$projectId.iam.gserviceaccount.com"
  
gcloud projects add-iam-policy-binding $projectId \
  --role="roles/iam.serviceAccountUser" \
  --member="serviceAccount:github-deploy@$projectId.iam.gserviceaccount.com"
  
gcloud projects add-iam-policy-binding $projectId \
  --role="roles/storage.admin" \
  --member="serviceAccount:github-deploy@$projectId.iam.gserviceaccount.com"
  
gcloud projects add-iam-policy-binding $projectId \
  --role="roles/artifactregistry.admin" \
gcloud projects add-iam-policy-binding $projectId \
  --role="roles/artifactregistry.admin" \
  --member="serviceAccount:github-deploy@$projectId.iam.gserviceaccount.com"
  --member="serviceAccount:github-deploy@$projectId.iam.gserviceaccount.com"
  
gcloud iam service-accounts create "app-runner" --project "$projectId"
  
gcloud projects add-iam-policy-binding $projectId \
  --role="roles/aiplatform.serviceAgent" \
  --member="serviceAccount:app-runner@$projectId.iam.gserviceaccount.com"
  
gcloud projects add-iam-policy-binding $projectId \
  --role="roles/aiplatform.user" \
  --member="serviceAccount:app-runner@$projectId.iam.gserviceaccount.com"
  
gcloud projects add-iam-policy-binding $projectId \
  --role="roles/iam.serviceAccountTokenCreator" \
  --member="serviceAccount:app-runner@$projectId.iam.gserviceaccount.com"

gcloud projects add-iam-policy-binding $projectId \
  --role="roles/datastore.owner" \
  --member="serviceAccount:app-runner@$projectId.iam.gserviceaccount.com"
  
gcloud projects add-iam-policy-binding $projectId \
  --role="roles/datastore.user" \
  --member="serviceAccount:app-runner@$projectId.iam.gserviceaccount.com"

gcloud projects add-iam-policy-binding $projectId \
  --role="roles/secretmanager.secretAccessor" \
  --member="serviceAccount:app-runner@$projectId.iam.gserviceaccount.com"
  
gcloud projects add-iam-policy-binding $projectId \
  --role="roles/cloudtasks.admin" \
  --member="serviceAccount:app-runner@$projectId.iam.gserviceaccount.com"

#gcloud services enable aiplatform.googleapis.com
#gcloud services enable analytics.googleapis.com
#gcloud services enable bigquery.googleapis.com
gcloud services enable storage.googleapis.com --project=$projectId
gcloud services enable logging.googleapis.com --project=$projectId
gcloud services enable sql-component.googleapis.com --project=$projectId
gcloud services enable monitoring.googleapis.com --project=$projectId
gcloud services enable compute.googleapis.com --project=$projectId
gcloud services enable cloudfunctions.googleapis.com --project=$projectId
gcloud services enable iamcredentials.googleapis.com --project=$projectId
gcloud services enable secretmanager.googleapis.com --project=$projectId
gcloud services enable artifactregistry.googleapis.com --project=$projectId
gcloud services enable run.googleapis.com --project=$projectId
gcloud services enable cloudbuild.googleapis.com --project=$projectId
gcloud services enable cloudtasks.googleapis.com --project=$projectId
#gcloud services enable translate.googleapis.com

gcloud artifacts repositories create docker --repository-format=docker --location=$location --project=$projectId
gcloud tasks queues create scheduler-prod --project=$projectId --location=$location
gcloud tasks queues create scheduler-dev --project=$projectId --location=$location