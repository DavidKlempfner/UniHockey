cls
cd C:\Develop\UniHockey\UniHockey

$UNIQUE_TAG=$(git rev-parse --short HEAD) # eg. a1b2c3d
$AWS_ACCOUNT = 767398108423
$AWS_REGION = "ap-southeast-2"

$ECR_DOMAIN = "$AWS_ACCOUNT.dkr.ecr.$AWS_REGION.amazonaws.com"
$REPO_NAME = "unihockey/unihockeyrepo"
$IMAGE_NAME = "$ECR_DOMAIN/$REPO_NAME"
$IMAGE_NAME_LATEST_TAG = "$($IMAGE_NAME):latest"
$IMAGE_NAME_COMMIT_HASH_TAG = "$($IMAGE_NAME):$UNIQUE_TAG"

docker build --provenance=false --tag $IMAGE_NAME_LATEST_TAG .

docker tag $IMAGE_NAME_LATEST_TAG $IMAGE_NAME_COMMIT_HASH_TAG

aws ecr get-login-password --region $AWS_REGION | docker login --username AWS --password-stdin $ECR_DOMAIN

docker push $IMAGE_NAME_LATEST_TAG
docker push $IMAGE_NAME_COMMIT_HASH_TAG