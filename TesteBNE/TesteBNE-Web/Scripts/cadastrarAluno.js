﻿$(document).ready(function () {
	var valor;
	var valorEscolhido;
	url = location.href;
	console.log(url);
	console.log("entrou aki");
	var parametroDaUrl = url.split("?")[1];

	// verifica se algum parametro foi passado pela url
	if (parametroDaUrl !== undefined) {

		console.log("dentro do if: " + parametroDaUrl);
		parametroDaUrl = parametroDaUrl.split("=")[1];
		console.log(parametroDaUrl);

		var id = parametroDaUrl;
		console.log("valor do id" + id)
		//faz a busca no banco de dados, buscando o objeto pelo id, o segundo parametro e uma funcao no caso estou chamando a funçao editar
		getPorId(id, editar);

	}
	else {
		$("#bntCadAluno").click(function () {

			var Aluno = cadastrarAluno();
			console.log("Objeto a ser inserido no banco :" + Aluno)
			Pessoa = JSON.parse(Aluno);
			console.log("nome do cara: " + Pessoa.Nome_Aluno);
			console.log(Pessoa);
			if (Pessoa.Nome_Aluno == "") {
				alert("campos obrigatórios não preenchidos");
			} else {
				Pessoa = JSON.stringify(Pessoa);
				console.log("depois do metodo stringfy: " + Pessoa);
				postAluno(Pessoa);
			}
		});
	}
});

function cadastrarAluno() {
	var aluno = JSON.stringify({
		Nome_Aluno: $("#txtNomeAluno").val()


	});
	return aluno;
};
//function postAluno(aluno) {
//	console.log("dentro do post" + aluno)
//	$.post("http://localhost:63689/api/Aluno", aluno, function () { }, 'json')
//};

function postAluno(pessoa) {
	$.ajax({

		url: 'http://localhost:63689/api/Aluno',
		data: pessoa,
		type: 'POST',
		contentType: 'application/json; charset=UTF-8',
		success: (function (retorno) {
			console.log("pessoa :" + pessoa + "success");
			console.log("data :" + retorno);
			alert("Cadastro efetuado com sucesso.");
			var url = location.href;
			url = url.split("/")[0] + "/index.html";
			window.location.assign(url);
		}),
		error: (function (retorno) {
			console.log("pessoa :" + pessoa + "success");
			console.log("data :" + retorno);
			console.log(retorno);
			if (retorno.status == 400) {
				alert("Usuário já cadastrado!");
			} else {
				alert("Algum erro inesperado ocorreu :-(!.");
			}

		})

	});
}