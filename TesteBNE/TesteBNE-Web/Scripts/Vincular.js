document.write(unescape("%3Cscript src='/Servicos/ajax.js' type='text/javascript'%3E%3C/script%3E"));

function vincular(id) {
	var disciplina = retornaDisciplinaPorId(id);
	disciplina.ID_Aluno = location.href.split("/")[5];
	putDisciplina(id, disciplina);
	console.log(location.href.split("/")[0]);
	window.location.assign(location.href.split("/")[0] + "/Disciplina/AdicionarDisciplina/" + disciplina.ID_Aluno);
}