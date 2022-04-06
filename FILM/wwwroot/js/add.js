function download__video(input)
{
    let block = document.querySelector(`#upload-file__text__video`);
    block.innerHTML = "";
    for(let i = 0; i < input.files.length; i++)
    {
    let file = input.files[i];
    let reader = new FileReader();
    reader.fileName = file.name;
    reader.readAsDataURL(file);
    reader.onload = function (readerEvt) {
        block.innerHTML += readerEvt.target.fileName + "</br>";
    }
}
}
function download__photo(input)
{
    let block = document.querySelector(`#upload-file__text__photo`);
    block.innerHTML = "";
    for(let i = 0; i < input.files.length; i++)
    {
    let file = input.files[i];
    let reader = new FileReader();
    reader.fileName = file.name;
    reader.readAsDataURL(file);
    reader.onload = function (readerEvt) {
        block.innerHTML += readerEvt.target.fileName + "</br>";
    }
}
}