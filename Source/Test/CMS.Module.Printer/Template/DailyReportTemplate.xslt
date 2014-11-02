<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
    xmlns:msxsl="urn:schemas-microsoft-com:xslt" exclude-result-prefixes="msxsl"
>
    <xsl:output method="text" indent="yes"/>
  <xsl:variable name="TotallyAmount"/>
  <xsl:variable name="TotallyOrderCount" />
  <xsl:variable name="Operator" />
  <xsl:variable name="OperateDate" />
  <xsl:template match="/">
    <xsl:variable name="Operator" select="@operator"/>
    <xsl:variable name="TotallyOrderCount"  select="@TotallyOrderCount"/>
    <xsl:variable name="TotallyAmount" select="@TotallyAmount" />
    <xsl:variable name="OperateDate" select="@operatedate" />
    <xsl:apply-templates select="*" />
  </xsl:template>
  
  <xsl:template match="entrances">
    <xsl:for-each select='./entrance' xml:space='preserve'>
      <xsl:value-of select='@name'/>                  <xsl:value-of select='amount'/>           <xsl:value-of select='count'/>
    </xsl:for-each>
    应收合计：<xsl:value-of select='$TotallyAmount'/>
       总单数：<xsl:value-of select='$TotallyOrderCount' />
    人均消费：<xsl:value-of select='$TotallyAmount' />
    打印时间：<xsl:value-of select='$OperateDate' />
       打印人：<xsl:value-of select='$Operator'/>
  </xsl:template>
    
</xsl:stylesheet>
