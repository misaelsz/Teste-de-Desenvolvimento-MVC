function cadastrarAluno() {
	var aluno = JSON.stringify({
		ID:null,
		Nome_Aluno: $("#txtNomeAluno").val(),
		ListaDisciplinas:null
		
	});
	return aluno;


}