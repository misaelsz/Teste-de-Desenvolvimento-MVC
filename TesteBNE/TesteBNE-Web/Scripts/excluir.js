
var btnConfirm = "";
function excluir(id) {

	document.getElementById('confirm').style.display = 'block'; " style=width:auto";
	console.log("Guid" + id);

	$("#btnConfirm").click(function () {
		btnConfirm = "sim";
		console.log("dentro do click" + btnConfirm);


		if (btnConfirm === 'sim') {
			console.log("dentro do if:" + btnConfirm);
			//faz a exclusao via ajax
			Delete(id);
		}
		document.getElementById('confirm').style.display = 'none';
	})

}