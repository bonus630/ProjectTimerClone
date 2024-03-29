<?xml version="1.0"?>
<!--
Permission is hereby granted, free of charge, to any person or organization obtaining a copy of the software and accompanying 
documentation covered by this license (the "Software") to use, reproduce, display, distribute, execute, and transmit the Software, 
and to prepare derivative works of the Software, and to permit third-parties to whom the Software is furnished to do so, all subject 
to the following:

The copyright notices in the Software and this entire statement, including the above license grant, the original location it was 
downloaded from, this restriction and the following disclaimer, must be included in all copies of the Software, in whole or in part, 
and all derivative works of the Software, unless such copies or derivative works are solely in the form of machine-executable object
code generated by a source language processor.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF 
MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE, TITLE AND NON-INFRINGEMENT. THE SOFTWARE MAY CONTAIN BUGS, ERRORS AND OTHER
PROBLEMS THAT COULD CAUSE SYSTEM FAILURES AND THE USE OF SUCH SOFTWARE IS ENTIRELY AT THE USER'S RISK. IN NO EVENT SHALL THE COPYRIGHT
HOLDERS OR ANYONE DISTRIBUTING THE SOFTWARE BE LIABLE FOR ANY DAMAGES OR OTHER LIABILITY, WHETHER IN CONTRACT, TORT OR OTHERWISE, 
ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

************************************************************************************************************************************
This file defines new UI elements that all workspaces will contain
************************************************************************************************************************************
-->
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:frmwrk="Corel Framework Data">
  <xsl:output method="xml" encoding="UTF-8" indent="yes"/>

  <!-- Use these elements for the framework to move the container from the app config file to the user config file -->
  <!-- Since these elements use the frmwrk name space, they will not be executed when the XSLT is applied to the user config file -->
  <frmwrk:uiconfig>
    <!-- The Application Info should always be the topmost frmwrk element -->
    <frmwrk:applicationInfo userConfiguration="true" />
  </frmwrk:uiconfig>

  <!-- Copy everything -->
  <xsl:template match="node()|@*">
    <xsl:copy>
      <xsl:apply-templates select="node()|@*"/>
    </xsl:copy>
  </xsl:template>

  <xsl:template match="uiConfig/items">
    <xsl:copy>
      <xsl:apply-templates select="node()|@*"/>
<!--Control in tool bar-->
      <itemData guid="48fcfd9d-b0bf-456d-8e40-aaa38eb8c8b0"
                type="wpfhost"
                hostedType="Addons\ProjectTimerClone\ProjectTimerClone.dll,ProjectTimerClone.ControlUI"
                enable="true"/>
<!--DropdownButton-->
		<!--<itemData guid='7e6b5490-14f6-475e-8dce-49d0176acdeb' type='dropDownDlgBtn' arrowStyle='down' 
				  caption='*Bind(DataSource=ProjectTimerCloneDS;Path=FormatedTime)' 
				  toolTip='*Bind(DataSource=ProjectTimerCloneDS;Path=FormatedTime)' 
				  dropDownRef='d74ef405-5b50-46ab-80d4-a655e22ad80d' 
				  length='100' enable='true'/>-->

		
<!--PopUp-->
        <!--<itemData guid="d74ef405-5b50-46ab-80d4-a655e22ad80d"
                type="wpfhost"
                hostedType="Addons\ProjectTimerClone\ProjectTimerClone.dll,ProjectTimerClone.PopUp"
                enable="true"/>-->
    </xsl:copy>
  </xsl:template>

  <!--Create a custom command bar below standard bar-->
  <xsl:template match="uiConfig/commandBars">
    <xsl:copy>
      <xsl:apply-templates select="node()|@*"/>

      <commandBarData guid="3cce5130-e98d-4e80-a078-0e644cdf70f1"
                      nonLocalizableName="Project Timer Clone"
                      userCaption="Project Timer Clone"
                      locked="true"
                      type="toolbar">
        <toolbar>
          <item  guidRef="48fcfd9d-b0bf-456d-8e40-aaa38eb8c8b0" dock="top"/>
			<!--<item  guidRef="7e6b5490-14f6-475e-8dce-49d0176acdeb" dock="top"/>-->
        </toolbar>
      </commandBarData>
    </xsl:copy>
  </xsl:template>

  <!--<xsl:template match="uiConfig/dialogs">
    <xsl:copy>
      <xsl:apply-templates select="node()|@*"/>

      <dialog guid="79c72097-2da1-4fbf-8436-f89abb1478b6"
                     popUp="true"
                      >
        
          <item  guidRef="d74ef405-5b50-46ab-80d4-a655e22ad80d" dock="top"/>
        
        </dialog>
      
    </xsl:copy>
  </xsl:template>-->
  <xsl:template match="@*|node()">
    <xsl:copy>
      <xsl:apply-templates select="@*|node()"/>
    </xsl:copy>
  </xsl:template>
  <xsl:template match="uiConfig/containers/container[@guid='bee85f91-3ad9-dc8d-48b5-d2a87c8b2109']/container[@guid='Framework_MainFrame-layout']/dockHost[@guid='894bf987-2ec1-8f83-41d8-68f6797d0db4']/toolbar[@guidRef='c2b44f69-6dec-444e-a37e-5dbf7ff43dae']">
    <xsl:copy-of select="."/>

    <toolbar guidRef="3cce5130-e98d-4e80-a078-0e644cdf70f1" dock="top" />

  </xsl:template>

</xsl:stylesheet>
