<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
    xmlns:msxsl="urn:schemas-microsoft-com:xslt" exclude-result-prefixes="msxsl"
>
    <xsl:output method="text" indent="yes"/>

  <xsl:template match="order">
                   琉香美食汇
    地址： 张家港市购物公园克拉水岸
    电话： 0512-58587868
    
~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~    
档口名: <xsl:value-of select='./@entrance'/>          流水号: <xsl:value-of select='@sales'/>
~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
    品名                   数量           单位           单价
    
    <xsl:for-each select='./dish' xml:space='preserve'>
      <xsl:value-of select='@name'/>                  <xsl:value-of select='quantity'/>           <xsl:value-of select='unit'/>           <xsl:value-of select='price'/>
    </xsl:for-each>
~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
                                                      总计：<xsl:value-of select='@amount'/>
                                              卡内余额：<xsl:value-of select='@cardBalance'/>
~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
操作人：<xsl:value-of select='@operator'/>             打印时间：<xsl:value-of select='@date'/>
~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
软件咨询：18616997273
  </xsl:template>
    
</xsl:stylesheet>
