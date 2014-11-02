<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
    xmlns:msxsl="urn:schemas-microsoft-com:xslt" exclude-result-prefixes="msxsl"
>
    <xsl:output method="text" indent="yes"/>

  <xsl:template match="order">
~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~    
档口名: <xsl:value-of select='./@entrance'/>          单据号: <xsl:value-of select='@orderno'/>
~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
    品名                   数量           单位
    
    <xsl:for-each select='./dish' xml:space='preserve'>
      <xsl:value-of select='@name'/>                  <xsl:value-of select='quantity'/>           <xsl:value-of select='unit'/>
    </xsl:for-each>
~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
                                               
                                               入单人: <xsl:value-of select='@amount'/>
                                              入单时间：<xsl:value-of select='@date'/>

  </xsl:template>
    
</xsl:stylesheet>
