<?xml version="1.0" encoding="utf-8"?>
<serviceModel xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema" name="EYECloudService" generation="1" functional="0" release="0" Id="e9b1911a-a772-4e31-a894-8418ad7c079c" dslVersion="1.2.0.0" xmlns="http://schemas.microsoft.com/dsltools/RDSM">
  <groups>
    <group name="EYECloudServiceGroup" generation="1" functional="0" release="0">
      <componentports>
        <inPort name="EYEServiceWebRole:Endpoint1" protocol="http">
          <inToChannel>
            <lBChannelMoniker name="/EYECloudService/EYECloudServiceGroup/LB:EYEServiceWebRole:Endpoint1" />
          </inToChannel>
        </inPort>
      </componentports>
      <settings>
        <aCS name="EYEServiceWebRole:Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" defaultValue="">
          <maps>
            <mapMoniker name="/EYECloudService/EYECloudServiceGroup/MapEYEServiceWebRole:Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" />
          </maps>
        </aCS>
        <aCS name="EYEServiceWebRoleInstances" defaultValue="[1,1,1]">
          <maps>
            <mapMoniker name="/EYECloudService/EYECloudServiceGroup/MapEYEServiceWebRoleInstances" />
          </maps>
        </aCS>
      </settings>
      <channels>
        <lBChannel name="LB:EYEServiceWebRole:Endpoint1">
          <toPorts>
            <inPortMoniker name="/EYECloudService/EYECloudServiceGroup/EYEServiceWebRole/Endpoint1" />
          </toPorts>
        </lBChannel>
      </channels>
      <maps>
        <map name="MapEYEServiceWebRole:Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" kind="Identity">
          <setting>
            <aCSMoniker name="/EYECloudService/EYECloudServiceGroup/EYEServiceWebRole/Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" />
          </setting>
        </map>
        <map name="MapEYEServiceWebRoleInstances" kind="Identity">
          <setting>
            <sCSPolicyIDMoniker name="/EYECloudService/EYECloudServiceGroup/EYEServiceWebRoleInstances" />
          </setting>
        </map>
      </maps>
      <components>
        <groupHascomponents>
          <role name="EYEServiceWebRole" generation="1" functional="0" release="0" software="C:\Users\sribo\Desktop\EYECloudService\EYECloudService\EYECloudService\csx\Release\roles\EYEServiceWebRole" entryPoint="base\x64\WaHostBootstrapper.exe" parameters="base\x64\WaIISHost.exe " memIndex="1792" hostingEnvironment="frontendadmin" hostingEnvironmentVersion="2">
            <componentports>
              <inPort name="Endpoint1" protocol="http" portRanges="80" />
            </componentports>
            <settings>
              <aCS name="Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" defaultValue="" />
              <aCS name="__ModelData" defaultValue="&lt;m role=&quot;EYEServiceWebRole&quot; xmlns=&quot;urn:azure:m:v1&quot;&gt;&lt;r name=&quot;EYEServiceWebRole&quot;&gt;&lt;e name=&quot;Endpoint1&quot; /&gt;&lt;/r&gt;&lt;/m&gt;" />
            </settings>
            <resourcereferences>
              <resourceReference name="DiagnosticStore" defaultAmount="[4096,4096,4096]" defaultSticky="true" kind="Directory" />
              <resourceReference name="EYEServiceWebRole.svclog" defaultAmount="[1000,1000,1000]" defaultSticky="true" kind="Directory" />
              <resourceReference name="EventStore" defaultAmount="[1000,1000,1000]" defaultSticky="false" kind="LogStore" />
            </resourcereferences>
          </role>
          <sCSPolicy>
            <sCSPolicyIDMoniker name="/EYECloudService/EYECloudServiceGroup/EYEServiceWebRoleInstances" />
            <sCSPolicyUpdateDomainMoniker name="/EYECloudService/EYECloudServiceGroup/EYEServiceWebRoleUpgradeDomains" />
            <sCSPolicyFaultDomainMoniker name="/EYECloudService/EYECloudServiceGroup/EYEServiceWebRoleFaultDomains" />
          </sCSPolicy>
        </groupHascomponents>
      </components>
      <sCSPolicy>
        <sCSPolicyUpdateDomain name="EYEServiceWebRoleUpgradeDomains" defaultPolicy="[5,5,5]" />
        <sCSPolicyFaultDomain name="EYEServiceWebRoleFaultDomains" defaultPolicy="[2,2,2]" />
        <sCSPolicyID name="EYEServiceWebRoleInstances" defaultPolicy="[1,1,1]" />
      </sCSPolicy>
    </group>
  </groups>
  <implements>
    <implementation Id="67aaffe9-7560-4aab-9ad3-0a7e4ce641fe" ref="Microsoft.RedDog.Contract\ServiceContract\EYECloudServiceContract@ServiceDefinition">
      <interfacereferences>
        <interfaceReference Id="bd9cbbc3-31bd-48e2-8cd0-937ce93971fe" ref="Microsoft.RedDog.Contract\Interface\EYEServiceWebRole:Endpoint1@ServiceDefinition">
          <inPort>
            <inPortMoniker name="/EYECloudService/EYECloudServiceGroup/EYEServiceWebRole:Endpoint1" />
          </inPort>
        </interfaceReference>
      </interfacereferences>
    </implementation>
  </implements>
</serviceModel>