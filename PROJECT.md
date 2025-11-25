
### Deploy on AWS App Runner

https://docs.aws.amazon.com/AmazonECR/latest/userguide/docker-push-ecr-image.html


Authenticate the Docker client to AWS ECR registry
> aws ecr get-login-password --region <region> | docker login --username AWS --password-stdin <ecr_container_id>

Build docker image
> docker build -t newsite .

Tag the image with the Amazon ECR registry, repository, and image tag name
> docker tag newsite:latest <ecr_container_id>/newsite:latest

Docker push command to push to ECR registry
> docker push <ecr_container_id>/newsite:latest


AWS RDS Postgres database

Database environment variables defined on AWS Key Management Service (KMS) and obtained by ECR