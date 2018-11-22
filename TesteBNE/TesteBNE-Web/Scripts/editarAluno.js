

function editar(resposta) {
	var e = resposta;
	console.log("retorno do callback" + e);

	console.log("retorno: " + JSON.stringify(e.Nome_Aluno));
	document.getElementById('txtNomeAluno').value = e.Nome_Aluno;
	

	$('#btnCadastrar').click(function () {

		e.Nome_Aluno = document.getElementById('txtNomeAluno').value;
		
		console.log("valores do objeto e" + e.Nome_Aluno);

		var id = e.ID;
		var pessoa = e;
		put(id, pessoa);
	});
}