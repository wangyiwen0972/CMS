<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
    xmlns:msxsl="urn:schemas-microsoft-com:xslt" exclude-result-prefixes="msxsl"
>
    <xsl:output method="text" indent="yes"/>

  <xsl:template match="order">
    档口: <xsl:value-of select='./@entrance'/> 设备: <xsl:value-of select='@machine'/> 操作: <xsl:value-of select='@operator'/>
    =================================================================
    菜品名称          数量           单价        金额(圆)
    =================================================================
    <xsl:for-each select='./dish' xml:space='preserve'>
      <xsl:value-of select='@name'/>           <xsl:value-of select='quantity'/>         <xsl:value-of select='price'/>         <xsl:value-of select='amount'/>
    </xsl:for-each>
    ================================================================
    ================================================================
    总计: <xsl:value-of select='@amount'/>
  </xsl:template>
    
</xsl:stylesheet>
