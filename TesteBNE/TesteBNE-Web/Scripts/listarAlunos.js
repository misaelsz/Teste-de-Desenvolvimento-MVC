function listar(ObjPessoa) {
	console.log(ObjPessoa);
	$.each(ObjPessoa, function (chave, valor) {
		//adicionando os objetos dentro da tabela com o comando append
		$("#listaPessoas tbody").append(
			"<tr>" +
			"<td>" + valor.nome + "</td>" +
			"<td>" + valor.email + "</td>" +
			"<td>" + valor.telefone + "</td>" +
			"<td>" + valor.Sexo + "</td>" +
			"<td>" + valor.idade + "</td>" +
			"<td>" + valor.Cep + "</td>" +
			// "<td class='btn-primary'><a href='file:///C:/Users/misaelzeferino/Documents/projetosAulaMarth/aula02Ajax/cadastro.html'><button type='button' onclick='editar(" + JSON.stringify(valor.id) + "); ' id='editar'>Editar</button></a></td>" +
			"<td><button type='button' onclick='carregarCadastroParaEdicao(" + JSON.stringify(valor.id) + "); ' id='editar'>Editar</button></td>" +
			"<td><button class='button-excluir' type='button' onclick='excluir(" + JSON.stringify(valor.id) + ");' id='remover'>X</button></td>"

		);
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

