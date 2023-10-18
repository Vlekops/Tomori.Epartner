let _dotnet = null;
let _profile = null;

function DotNetInit(dotNetObjectReference) {
    _dotnet = dotNetObjectReference;
}

function DotNetInitProfile(dotNetObjectReference) {
    _profile = dotNetObjectReference;
}

function ShowBodyLoading(value) {
    if (_dotnet != null)
        _dotnet.invokeMethodAsync('SetBodyLoading', value);
}
onInactive(idleMinute * (60 * 1000), function () {
    _dotnet.invokeMethodAsync('DoLogoff', `Aplikasi tidak digunakan lebih dari ${idleMinute} menit, silahkan melakukan login kembali!`);
});

function onInactive(ms, cb) {
    var wait = setTimeout(cb, ms);
    document.onmousemove = document.mousedown = document.mouseup = document.onkeydown = document.onkeyup = document.focus = function () {
        clearTimeout(wait);
        wait = setTimeout(cb, ms);
    };
}

function Base64ToFile(filename, mimeTypeValue, base64String) {
    let downloadLink = document.createElement('a');

    downloadLink.href = `data:${mimeTypeValue};base64,${base64String}`;;
    downloadLink.download = filename;
    downloadLink.click();
}

function PreviewFile(filename, mimeTypeValue, base64String) {
    var base64ToBlob = (type, base64) => {
        const binStr = atob(base64);
        const len = binStr.length;
        const arr = new Uint8Array(len);
        for (let i = 0; i < len; i++) {
            arr[i] = binStr.charCodeAt(i);
        }
        return new Blob([arr], { type: type });
    };

    const blob = base64ToBlob(mimeTypeValue, base64String);
    const url = URL.createObjectURL(blob);
    const pdfWindow = window.open('about:blank', '_blank');
    pdfWindow.document.write(`<html><head><title>${filename}</title><style>*{margin: 0;padding: 0;overflow: hidden;background: #2b2b2b;}</style></head><body>`);
    pdfWindow.document.write(`<iframe width="100%" height="100%" src="${url}"></iframe>`);
    pdfWindow.document.write("</body></html>");
}