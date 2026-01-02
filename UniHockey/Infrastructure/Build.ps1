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

#NOTE! Must first remove value in Alternate domain names in cloudfront distribution AND disable the distribution
#aws cloudformation delete-stack --stack-name UniHockeyApp-DevStack
#aws cloudformation wait stack-delete-complete --stack-name UniHockeyApp-DevStack

#TODO:
#Set up a dev env and a prod env. You'll need to manually create the certs and the route53 hosted zone.
#Set up PrivateLink for Cloudfront -> ALB
#Set up Lambda@Edge
#Learn WAF
#Learn API Gateway