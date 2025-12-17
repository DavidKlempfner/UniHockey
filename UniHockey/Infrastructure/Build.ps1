cls
$Dir = "C:\Develop\UniHockey\UniHockey"
cd $Dir
. "$Dir\Infrastructure\Variables.ps1"

$ImageNameLatestTag = "$($ImageName):latest"

docker build --provenance=false --tag $ImageNameLatestTag .

docker tag $ImageNameLatestTag $ImageNameCommitHashTag

aws ecr get-login-password --region $AwsRegion | docker login --username AWS --password-stdin $EcrDomain

docker push $ImageNameLatestTag
docker push $ImageNameCommitHashTag