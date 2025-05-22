function downloadFileFromBytes(filename, base64) {
    const link = document.createElement('a');
    link.href = 'data:application/vnd.openxmlformats-officedocument.spreadsheetml.sheet;base64,' + base64;
    link.download = filename.endsWith('.xlsx') ? filename : filename.replace('.xlsx');
    document.body.appendChild(link);
    link.click();
    document.body.removeChild(link);
}