<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
<xsl:template match="node()|@*">
  <xsl:copy>
    <xsl:apply-templates select="node()|@*"/>
  </xsl:copy>
</xsl:template>
<xsl:template match="/EplanPxfRoot/O76/S54x1432/@A961">
  <!--Edit the following line to reflect the desired scaling factor-->
  <xsl:attribute name="A961"><xsl:value-of select="/EplanPxfRoot/O76/S54x1432/@A961 * 1.25"/></xsl:attribute>
</xsl:template>
</xsl:stylesheet>