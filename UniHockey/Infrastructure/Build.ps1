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

#TODO:
#Set up IP restrictions for dev account
#Set up PrivateLink for Cloudfront -> ALB
#Set up Lambda@Edge
#Learn WAF
#Learn API Gateway
#Id: ALBOrigin #TODO RENAME WITH ENVNAME