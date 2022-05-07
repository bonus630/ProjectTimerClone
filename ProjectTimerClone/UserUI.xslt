<?xml version="1.0"?>

<xsl:stylesheet version="1.0"
								xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
								xmlns:frmwrk="Corel Framework Data"
								exclude-result-prefixes="frmwrk">
  <xsl:output method="xml" encoding="UTF-8" indent="yes"/>

  <!-- Use these elements for the framework to move the container from the app config file to the user config file -->
  <!-- Since these elements use the frmwrk name space, they will not be executed when the XSLT is applied to the user config file -->
  <frmwrk:uiconfig>
    <!-- The Application Info should always be the topmost frmwrk element -->
    <frmwrk:compositeNode xPath="/uiConfig/commandBars/commandBarData[@guid='c2b44f69-6dec-444e-a37e-5dbf7ff43dae']"/>
    <frmwrk:compositeNode xPath="/uiConfig/frame"/>
  </frmwrk:uiconfig>

  <!-- Copy everything -->
  <xsl:template match="node()|@*">
    <xsl:copy>
      <xsl:apply-templates select="node()|@*"/>
    </xsl:copy>
  </xsl:template>

  <xsl:template match="commandBarData[@guid='09FA126F-F823-43E0-9C1D-59047B7B7398']/toolbar">
    <xsl:copy>
      <xsl:apply-templates select="node()|@*"/>

      <xsl:if test="not(./item[@guidRef='48fcfd9d-b0bf-456d-8e40-aaa38eb8c8b0'])">
        <item guidRef="c42b6524-4865-4532-a042-04600759ba39"/>
      </xsl:if>
  


    </xsl:copy>
  </xsl:template>

  <xsl:template match="uiConfig/containers/container[@guid='bee85f91-3ad9-dc8d-48b5-d2a87c8b2109']/container[@guid='Framework_MainFrame-layout']/dockHost[@guid='894bf987-2ec1-8f83-41d8-68f6797d0db4']/toolbar[@guidRef='c2b44f69-6dec-444e-a37e-5dbf7ff43dae']">
    <xsl:copy>
      <xsl:apply-templates select="node()|@*"/>

      <xsl:if test="not(./toolbar[@guidRef='3cce5130-e98d-4e80-a078-0e644cdf70f1'])">
        <toolbar guidRef="3cce5130-e98d-4e80-a078-0e644cdf70f1" dock="top"/>
      </xsl:if>
    </xsl:copy>
  </xsl:template>


  <xsl:template match="uiConfig/states/state[1]/container[@guidRef='bee85f91-3ad9-dc8d-48b5-d2a87c8b2109']/layout/dockHost[@guid='894bf987-2ec1-8f83-41d8-68f6797d0db4']/toolbar[@guidRef='c2b44f69-6dec-444e-a37e-5dbf7ff43dae']">
    <xsl:copy>
      <xsl:apply-templates select="node()|@*"/>

      <xsl:if test="not(./toolbar[@guidRef='3cce5130-e98d-4e80-a078-0e644cdf70f1'])">
        <toolbar guidRef="3cce5130-e98d-4e80-a078-0e644cdf70f1" dock="top"/>
      </xsl:if>
    </xsl:copy>
  </xsl:template>
 
    <xsl:template match="uiConfig/dialogs">
    <xsl:copy>
      <xsl:apply-templates select="node()|@*"/>

      <xsl:if test="not(./dialog[@guidRef='79c72097-2da1-4fbf-8436-f89abb1478b6'])">
        <dialog guidRef="79c72097-2da1-4fbf-8436-f89abb1478b6" dock="top"/>
      </xsl:if>
    </xsl:copy>
  </xsl:template>
   <xsl:template match="uiConfig/dialogs/dialog[@guid='79c72097-2da1-4fbf-8436-f89abb1478b6']">
    <xsl:copy>
      <xsl:apply-templates select="node()|@*"/>

      <xsl:if test="not(./item[@guidRef='d74ef405-5b50-46ab-80d4-a655e22ad80d'])">
        <item guidRef="79c72097-2da1-4fbf-8436-f89abb1478b6" dock="top"/>
      </xsl:if>
    </xsl:copy>
  </xsl:template>

</xsl:stylesheet>