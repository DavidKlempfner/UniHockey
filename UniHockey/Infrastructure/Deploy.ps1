cls
$Dir = "C:\Develop\UniHockey\UniHockey\Infrastructure"
cd $Dir
. "$Dir\Variables.ps1"

$AppName = "UniHockeyApp"
$EnvName = "Dev"
$VpcCidr = "10.0.0.0/16"
$PublicSubnet1Cidr = "10.0.1.0/24"
$PublicSubnet2Cidr = "10.0.2.0/24"
$PrivateSubnet1Cidr = "10.0.101.0/24"
$PrivateSubnet2Cidr = "10.0.102.0/24"
$AvailabilityZone1 = "ap-southeast-2a"
$AvailabilityZone2 = "ap-southeast-2b"
$InitialTaskCount = 2
$EcsClusterSuffix= "ECSCluster"
$EcsServiceSuffix = "ECSService"
$CloudfrontSecurityHeader = "X-Origin-Verify"

aws cloudformation deploy `
 --template-file $Dir/ecs-fargate-template.yaml `
 --stack-name $AppName-$($EnvName)Stack `
 --parameter-overrides `
    EnvName=$EnvName `
    VpcCidr=$VpcCidr `
    PublicSubnet1Cidr=$PublicSubnet1Cidr `
    PublicSubnet2Cidr=$PublicSubnet2Cidr `
    PrivateSubnet1Cidr=$PrivateSubnet1Cidr `
    PrivateSubnet2Cidr=$PrivateSubnet2Cidr `
    AvailabilityZone1=$AvailabilityZone1 `
    AvailabilityZone2=$AvailabilityZone2 `
    ContainerImage=$ImageNameCommitHashTag `
    InitialTaskCount=$InitialTaskCount `
    EcsClusterSuffix=$EcsClusterSuffix `
    EcsServiceSuffix=$EcsServiceSuffix `
    CloudfrontSecurityHeader=$CloudfrontSecurityHeader `
 --capabilities CAPABILITY_NAMED_IAM