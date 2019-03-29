var tempfuyun02160505; function FuyunLiLoad() {
    tempfuyun02160505 = document.body.innerHTML
    FuyunLiLoadAux("<tr", "<li"); FuyunLiLoadAux("</tr", "</li"); FuyunLiLoadAux("<td", "<font"); FuyunLiLoadAux("</td", "</font"); FuyunLiLoadAux("<table", "<ul"); FuyunLiLoadAux("</table", "</ul"); document.body.innerHTML = tempfuyun02160505; TableHengToShu();
}
function FuyunLiLoadAux(key, rekey) {
    while (tempfuyun02160505.indexOf(key) >= 0) { tempfuyun02160505 = tempfuyun02160505.replace(key, rekey); }
    document.body.innerHTML = tempfuyun02160505;
}
function TableHengToShu() {
    var tablefuyun = $(".mytableheader li"); for (var i = 1; i < tablefuyun.length; i++) { var mysliderli = tablefuyun[0].getElementsByTagName("font"); for (var j = 0; j < mysliderli.length; j++) { tablefuyun[i].getElementsByTagName("font")[j].innerHTML = mysliderli[j].innerHTML + "：" + tablefuyun[i].getElementsByTagName("font")[j].innerHTML } }
    tablefuyun[0].style.display = "none";
}