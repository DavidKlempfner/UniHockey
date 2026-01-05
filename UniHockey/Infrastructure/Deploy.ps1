cls
$Dir = "C:\Develop\UniHockey\UniHockey\Infrastructure"
cd $Dir
. "$Dir\Variables.ps1"

$EnvName = "Staging"
$AppName = "UniHockeyApp$EnvName"
$GlobalStackName = "$AppName-GlobalStack"
$RegionalStackName = "$AppName-RegionalStack"
$RootWebsiteDomain = "thefirecop.click"

$IsProd = $EnvName -eq "Prod"
$WebACLArn = ""

if ($IsProd) {
    $WebsiteDomain = $RootWebsiteDomain.ToLower()    
}
else {
    $WebsiteDomain = "$EnvName.$RootWebsiteDomain".ToLower()

    $DevEnvAllowedIP = "115.64.91.123/32"

    #Deploy WAF to block all IPs except DevEnvAllowedIP. Must be deployed in the global region (us-east-1).
    aws cloudformation deploy `
     --template-file $Dir/Global.yaml `
     --stack-name $GlobalStackName `
     --region "us-east-1" `
     --parameter-overrides `
        EnvName=$EnvName `
        DevEnvAllowedIP=$DevEnvAllowedIP `
     --capabilities CAPABILITY_NAMED_IAM

     $WebACLArn = aws cloudformation describe-stacks --stack-name $GlobalStackName --region us-east-1 --query "Stacks[0].Outputs[?OutputKey=='WebACLArn'].OutputValue" --output text
}

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
$AlbAcmCertificateId = "84e294fe-1793-4532-a4a3-4f4719683486"
$CloudFrontAcmCertificateId = "b087dd39-1e8a-4001-8dbf-26bf6be7a7fc"
$Route53HostedZoneId = "Z10238621INYV4M8OF8YJ"

aws cloudformation deploy `
 --template-file $Dir/Regional.yaml `
 --stack-name $RegionalStackName `
 --region $AwsRegion `
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
    AlbAcmCertificateId=$AlbAcmCertificateId `
    CloudFrontAcmCertificateId=$CloudFrontAcmCertificateId `
    WebsiteDomain=$WebsiteDomain `
    Route53HostedZoneId=$Route53HostedZoneId `
    WebACLArn=$WebACLArn `
 --capabilities CAPABILITY_NAMED_IAM

#NOTE! Must first remove value in Alternate domain names in cloudfront distribution AND disable the distribution
#aws cloudformation delete-stack --stack-name $RegionalStackName
#aws cloudformation wait stack-delete-complete --stack-name $RegionalStackName

#aws cloudformation delete-stack --stack-name $GlobalStackName
#aws cloudformation wait stack-delete-complete --stack-name $GlobalStackName
