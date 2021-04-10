function descargarPDF(pdf) {
    var a = document.createElement("a");
    a.href = pdf;
    a.download = "pdfReporte.pdf";
    a.click();
}
