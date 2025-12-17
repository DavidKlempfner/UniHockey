#Variables used in build and deploy

$UniqueTag=$(git rev-parse --short HEAD)
$AwsAccount = 767398108423
$AwsRegion = "ap-southeast-2"
$EcrDomain = "$AwsAccount.dkr.ecr.$AwsRegion.amazonaws.com"
$RepoName = "unihockey/unihockeyrepo"
$ImageName = "$EcrDomain/$RepoName"
$ImageNameCommitHashTag = "$($ImageName):$UniqueTag"