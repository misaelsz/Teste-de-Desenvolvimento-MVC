
//function postAluno(aluno) {
//	console.log("dentro do post" + aluno)
//	$.post("http://localhost:63689/api/Aluno", aluno, function () { }, 'json')
//};

//document.write(unescape("%3Cscript src='Scripts/editarAluno.js' type='text/javascript'%3E%3C/script%3E"));

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
			url = url.split("/")[0] + "/Aluno/IndexAluno";
			window.location.assign(url);
		}),
		error: (function (retorno) {
			console.log("pessoa :" + pessoa + "success");
			console.log("data :" + retorno);
			console.log(retorno);
			if (retorno.status === 400) {
				alert("Usuário já cadastrado!");
			} else {
				alert("Algum erro inesperado ocorreu :-(!.");
			}

		})

	});
}

function get(funcao) {
	$.ajax({
		url: 'http://localhost:63689/api/Aluno',
		method: 'GET'
	}).done(function (data) {
		funcao(data);
	});
}

function getPorId(id) {
	$.ajax({
		url: 'http://localhost:63689/api/Aluno/' + id,
		method: 'GET',
		contentType: 'application/json; charset=UTF-8',
	}).then(function (resposta) {
		console.log("dentro da requisicao" + resposta);
		editar(resposta);
	})

}

function getPorNome(nome, funcao) {
	console.log("O nome e:" + nome);
	JSON.stringify(nome);
	console.log(nome);
	$.ajax({
		url: 'http://localhost:52698/api/pessoa/?nome=' + nome,
		method: 'GET',
		contentType: 'application/json; charset=UTF-8',
	}).then(function (a) {
		console.log("retorno do get por nome: " + a)
		funcao(a);
	})
}

function put(id, pessoa) {
	$.ajax({
		url: 'http://localhost:63689/api/Aluno/' + id,
		method: 'PUT',
		data: JSON.stringify(pessoa),
		contentType: 'application/json; charset=UTF-8',
	}).then(function (a) {
		alert("sucesso");
		console.log("retorno put" + a);
		window.location.assign("./index.html");
	})
}


function Delete(id) {
	$.ajax({
		url: 'http://localhost:63689/api/Aluno/' + id,
		method: 'DELETE',
		contentType: 'application/json; charset=UTF-8',
	}).then(function (e) {
		$("#remover").parent().parent().parent().remove();
		var ObjPessoa = null;
		$.ajax({
			url: 'http://localhost:63689/api/Aluno',
			method: 'GET'
		}).done(function (data) {
			ObjPessoa = [];
			ObjPessoa = data;
			console.log("data Json" + JSON.stringify(data));

			console.log("objJSON : " + ObjPessoa);
			var url = location.href;
			url = url.split("/")[0] + "/Aluno/IndexAluno";
			window.location.assign(url);
		});
	})
}

function editar(resposta) {
	var e = resposta;
	console.log("retorno do callback" + e);

	console.log("retorno: " + JSON.stringify(e.Nome_Aluno));
	document.getElementById('txtNomeAluno').value = e.Nome_Aluno;


	$('#bntCadAluno').click(function () {

		e.Nome_Aluno = document.getElementById('txtNomeAluno').value;

		console.log("valores do objeto e" + e.Nome_Aluno);

		var id = e.ID;
		var pessoa = e;
		put(id, pessoa);
	});
}