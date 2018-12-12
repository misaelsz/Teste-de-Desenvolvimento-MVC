document.write(unescape("%3Cscript src='/Servicos/ajax.js' type='text/javascript'%3E%3C/script%3E"));
var btnConfirm = "";
function excluir(id) {

	document.getElementById('ExcluirConfirm').style.display = 'block'; " style=width:auto";
	console.log("Guid" + id);

	$("#btnConfirm").click(function () {
		btnConfirm = "sim";
		console.log("dentro do click" + btnConfirm);


		if (btnConfirm === 'sim') {
			console.log("dentro do if:" + btnConfirm);
			//faz a exclusao via ajax
			Delete(id);
		}
		document.getElementById('ExcluirConfirm').style.display = 'none';
	})

}