using ProjectRecipeBack.Domain.Enum;
using ProjectRecipeBack.Domain;
using ProjectRecipeBack.Repository.Repository;
using ProjectRecipeBack.Repository.Interface;
using ProjectRecipeBack.Services.Interface;
using ProjectRecipeBack.Services.Services;

internal class Program
{
    private static void Main(string[] args)
    {

        //  necessario refazer depois que colocou a injeção de dependencia nao pode chamar com new
        //  nao funciona mais

        //**************************************************************** INICIO DA CATEGORIES
        //Cadastrar categoria
        /*Console.WriteLine("Testando o Domain Category");

        Categories nova = new Categories();

        Console.WriteLine("Cadastrando uma categoria");
        Console.WriteLine("Informe o nome da categoria");

        nova.Category = Console.ReadLine();
        
        Console.WriteLine("categoria cadastrada " + nova.Category);

        //ICategories novaCategoria = new CategoriesRepository();
        ICategoriesServices novaCategoria = new CategoriesServices();

        novaCategoria.Add(nova);*/

        //Deletar categoria
        /*Console.WriteLine("Testando o Domain Categories");

        Console.WriteLine("Deletando uma categoria");
        Console.WriteLine("Informe o número da categoria");

        int deletar = Convert.ToInt32(Console.ReadLine());
        
        Console.WriteLine("categoria deletar " + deletar);

        //ICategories novaCategoria = new CategoriesRepository();
          ICategoriesServices novaCategoria = new CategoriesServices();

        novaCategoria.Delete(deletar);*/


        //Deletar categoria SOMENTE com métodos existentes no serviço
        /*Console.WriteLine("Testando o Domain Category");

        Console.WriteLine("Deletando uma categoria pelo método DeleteId existente apenas no Services");
        Console.WriteLine("Informe o número da categoria");

        int deletar = Convert.ToInt32(Console.ReadLine());
        
        Console.WriteLine("categoria deletar " + deletar);

        CategoriesServices novaCategoria = new CategoriesServices();

        novaCategoria.DeleteId(deletar);*/


        //Alterar categoria
        /* Console.WriteLine("Testando o Domain Category");

         Categories nova = new Categories();

         Console.WriteLine("Alterando uma categoria");
         Console.WriteLine("Informe o id da categoria");
         nova.Id = Convert.ToInt32(Console.ReadLine());

         Console.WriteLine("Informe o novo nome da categoria");
         nova.Category = Console.ReadLine();

         Console.WriteLine("categoria a ser alterada " + nova.Id + " " + nova.Category);

         //ICategories novaCategoria = new CategoriesRepository();
         ICategoriesServices novaCategoria = new CategoriesServices();


         novaCategoria.Update(nova);*/

        //Listar categoria geral
        /*Console.WriteLine("Listando todas as categorias");
        //ICategories novaCategoria = new CategoriesRepository();
        ICategoriesServices novaCategoria = new CategoriesServices();


        List<Categories> dados = new List<Categories>();

        dados = novaCategoria.GetAll();

        for (int i = 0; i < dados.Count; i++)
        {
            Console.WriteLine(dados[i].Id + " " + dados[i].Category);
        }*/


        //Listar categoria apenas um
        /*Console.WriteLine("Listando apenas um item da categoria");
        //ICategories novaCategoria = new CategoriesRepository();
        ICategoriesServices novaCategoria = new CategoriesServices();


        Categories dados = new Categories();

        Console.WriteLine("Informe o id da categoria");

        int id = Convert.ToInt32(Console.ReadLine());

        dados = novaCategoria.Get(id);

            Console.WriteLine(dados.Id + " " + dados.Category);*/


        //**************************************************************** INICIO DA DIFFICULTIES
        //Cadastra dificulties
        /*Console.WriteLine("Testando o Domain Difficulties");

        Difficulties nova = new Difficulties();

        Console.WriteLine("Cadastrando uma dificuldade");
        Console.WriteLine("Informe o nome da dificuldade");

        nova.Description = Console.ReadLine();

        Console.WriteLine("difficulties cadastrado " + nova.Description);

        //IDifficulties novaDificuldade = new DifficultiesRepository();
        IDifficultiesServices novaDificuldade = new DifficultiesServices();


        novaDificuldade.Add(nova);*/


        //Deletar difficulties
        /*Console.WriteLine("Testando o Domain Difficulties");

        Console.WriteLine("Deletando uma dificuldade");
        Console.WriteLine("Informe o número da dificuldade");

        int deletar = Convert.ToInt32(Console.ReadLine());
        
        Console.WriteLine("dificulties deletar " + deletar);

        //IDifficulties novaDificuldade = new DifficultiesRepository();
        IDifficultiesServices novaDificuldade = new DifficultiesServices();


        novaDificuldade.Delete(deletar);*/


        //Listar difficulties geral
        /*Console.WriteLine("Listando todas as dificuldades");

        //IDifficulties novaDificuldade = new DifficultiesRepository();
        IDifficultiesServices novaDificuldade = new DifficultiesServices();


        List<Difficulties> dados = new List<Difficulties>();

        dados = novaDificuldade.GetAll();

        for (int i = 0; i < dados.Count; i++)
        {
            Console.WriteLine(dados[i].Id + " " + dados[i].Description);
        }*/


        //Listar categoria apenas um
        /*Console.WriteLine("Listando apenas um item da difficulties");

       //IDifficulties novaDificuldade = new DifficultiesRepository();
        IDifficultiesServices novaDificuldade = new DifficultiesServices();


        Difficulties dados = new Difficulties();    

        Console.WriteLine("Informe o id da dificuldade");

        int id = Convert.ToInt32(Console.ReadLine());

        dados = novaDificuldade.Get(id);

            Console.WriteLine(dados.Id + " " + dados.Description);*/


        //Alterar dificuldade
        /*Console.WriteLine("Testando o Domain Difficulties");

        Difficulties nova = new Difficulties();

        Console.WriteLine("Alterando uma dificuldade");
        Console.WriteLine("Informe o id da dificuldade");
        nova.Id = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Informe o novo nome da dificuldade");
        nova.Description = Console.ReadLine();

        Console.WriteLine("dificuldade a ser alterada " + nova.Id + " " + nova.Description);

        //IDifficulties novaDificuldade = new DifficultiesRepository();
        IDifficultiesServices novaDificuldade = new DifficultiesServices();


        novaDificuldade.Update(nova);*/



        //**************************************************************** INICIO DA EVALUTION
        //Cadastra evaluation
        /*Console.WriteLine("Testando o Domain Evaluation");

        Evaluation nova = new Evaluation();

        Console.WriteLine("Cadastrando uma avaliação");

        Console.WriteLine("Informe a descrição da avaliação");
        nova.Name = Console.ReadLine();

        Console.WriteLine("Informe o id da receita associada ");
        nova.IdRecipe= Convert.ToInt32(Console.ReadLine()); 

        nova.Approval = ApprovalEnum.Approved;
        nova.Grade = GradeEnum.Nota1;
        Console.WriteLine("evaluation cadastrado " + nova.Name);

        //IIngredients novoIngrediente = new IngredientsRepository();
        IEvaluationServices novoAprovacao = new EvaluationServices();

        novoAprovacao.Add(nova);*/


        //Deletar Evaluations
        /*Console.WriteLine("Testando o Domain Evaluations");

        Console.WriteLine("Deletando uma avaiação");
        Console.WriteLine("Informe o id da avaliação");

        int deletar = Convert.ToInt32(Console.ReadLine());
        
        Console.WriteLine("evaluations deletar " + deletar);

        //Evaluations novoAvaliacao = new EvaluationsRepository();
        IEvaluationServices novoAvaliacao = new EvaluationServices();


        novoAvaliacao.Delete(deletar);*/


        //Listar evaluations geral
        /*Console.WriteLine("Listando todas as avaliações");

         //IEvaluations novoAvaliacao = new EvauationRepository();
         IEvaluationServices novoAvaliacao = new EvaluationServices();


         List<Evaluation> dados = new List<Evaluation>();

         dados = novoAvaliacao.GetAll();

         for (int i = 0; i < dados.Count; i++)
         {
             Console.WriteLine(dados[i].Id + " " + dados[i].Name + " " + dados[i].Grade);
         } */


        //Listar evaluation apenas um
        /*Console.WriteLine("Listando apenas um item/elemento da avaliação");

        //IEvaluation novoAvaliacao = new EvaluationRepository();
         IEvaluationServices novoAvaliacao = new EvaluationServices();


         Evaluation dados = new Evaluation();    

         Console.WriteLine("Informe o id da avaliação");

         int id = Convert.ToInt32(Console.ReadLine());

         dados = novoAvaliacao.Get(id);

             Console.WriteLine(dados.Id + " " + dados.Name + " " + dados.Grade);*/


        //Alterar avaliação
        /*Console.WriteLine("Testando o Domain Evaluation");

         Evaluations nova = new Evaluations();

         Console.WriteLine("Alterando uma avaliação");
         Console.WriteLine("Informe o id da avaliação");
         nova.Id = Convert.ToInt32(Console.ReadLine());

         Console.WriteLine("Informe a nova avaliação da receita");
         nova.Name = Console.ReadLine();

         Console.WriteLine("avaliacao a ser alterada " + nova.Id + " " + nova.Name);

         //IEvaluation novoAvaliacao = new EvaluationRepository();
         IEvaluationServices novoAvaliacao = new EvaluationServices();


         novoAvaliacao.Update(nova);*/








        //**************************************************************** INICIO DA INGREDIENTS
        //Cadastra ingredients
        /*Console.WriteLine("Testando o Domain Ingredients");

        Ingredients nova = new Ingredients();

        Console.WriteLine("Cadastrando um ingrediente");

        Console.WriteLine("Informe o nome do ingrediante");
        nova.Description = Console.ReadLine();

        Console.WriteLine("Informe a quantidade do ingrediante");
        nova.Quantity= Console.ReadLine();

        Console.WriteLine("Informe o Id que o ingrediente pertence");
        nova.IdRecipe = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("ingredients cadastrado " + nova.Description);

        //IIngredients novoIngrediente = new IngredientsRepository();
        IIngredientsServices novoIngrediente = new IngredientsServices();


        novoIngrediente.Add(nova);*/


        //Deletar Ingredients
        /*Console.WriteLine("Testando o Domain Ingredients");

        Console.WriteLine("Deletando um ingrediente");
        Console.WriteLine("Informe o id do ingrediente");

        int deletar = Convert.ToInt32(Console.ReadLine());
        
        Console.WriteLine("ingredients deletar " + deletar);

        //Ingredients novoIngrediente = new IngredientsRepository();
        IIngredientsServices novoIngrediente = new IngredientsServices();


        novoIngrediente.Delete(deletar);*/


        //Listar ingredients geral
        /*Console.WriteLine("Listando todos os ingredientes");

         //IIngredients novoIngrediente = new IngredientsRepository();
         IIngredientsServices novoIngrediente = new IngredientsServices();


         List<Ingredients> dados = new List<Ingredients>();

         dados = novoIngrediente.GetAll();

         for (int i = 0; i < dados.Count; i++)
         {
             Console.WriteLine(dados[i].Id + " " + dados[i].Description);
         }*/


        //Listar ingredients apenas um
        /*Console.WriteLine("Listando apenas um item do ingrediente");

        //IIngredients novoIngrediente = new IngredientsRepository();
         IIngredientsServices novoIngrediente = new IngredientsServices();


         Ingredients dados = new Ingredients();    

         Console.WriteLine("Informe o id do ingrediente");

         int id = Convert.ToInt32(Console.ReadLine());

         dados = novoIngrediente.Get(id);

             Console.WriteLine(dados.Id + " " + dados.Description);*/


        //Alterar ingrediente
        /* Console.WriteLine("Testando o Domain Ingredients");

         Ingredients nova = new Ingredients();

         Console.WriteLine("Alterando um ingrediente");
         Console.WriteLine("Informe o id do ingrediente");
         nova.Id = Convert.ToInt32(Console.ReadLine());

         Console.WriteLine("Informe o novo nome do ingrediente");
         nova.Description = Console.ReadLine();

         Console.WriteLine("Informe a nova quantidade do ingrediente");
         nova.Quantity = Console.ReadLine();

         Console.WriteLine("Informe o id da nova receita");
         nova.IdRecipe = Convert.ToInt32(Console.ReadLine());    

         Console.WriteLine("ingrediente a ser alterado " + nova.Id + " " + nova.Description);

         //IUsers novoUsuario = new UsersRepository();
         IIngredientsServices novoIngrediente= new IngredientsServices();


         novoIngrediente.Update(nova);*/









        //**************************************************************** INICIO DA RECIPES
        //Cadastra recipes
        /*
        Console.WriteLine("Testando o Domain Recipes");

        Recipes nova= new Recipes();

        Console.WriteLine("Cadastrando uma receita");

        Console.WriteLine("Informe o nome da receita");
        nova.Title = Console.ReadLine();

        Console.WriteLine("Informe a prepação da receita");
        nova.Preparation= Console.ReadLine();

        Console.WriteLine("Informe a classificação da receita");
        nova.Classification = Console.ReadLine();

        Console.WriteLine("Informe o tempo da receita");
        nova.Time = Console.ReadLine();

        Console.WriteLine("Informe a foto da receita");
        nova.Photo = Console.ReadLine();

        Console.WriteLine("Informe a gastronomia da receita");
        nova.Gastronomy = GastronomyEnum.VeganGastronomy;

        Console.WriteLine("Informe o id do usuário da receita");
        nova.IdUser = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Informe o id da dificuldade da receita");
        nova.IdDifficulty = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Informe o id da categoria da receita");
        nova.IdCategory = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Informe a aprovação da receita");
        nova.Approval = ApprovalEnum.NoApproved;

        Console.WriteLine("Marque o favorito da receita");
        nova.Favorite = FavoriteEnum.Favorite;


        Console.WriteLine("recipes cadastrado " + nova.Title);

        IRecipesServices novoReceita = new RecipesServices();


        novoReceita.Add(nova);
        */


        //Deletar Ingredients
        /*Console.WriteLine("Testando o Domain Ingredients");

        Console.WriteLine("Deletando um ingrediente");
        Console.WriteLine("Informe o id do ingrediente");

        int deletar = Convert.ToInt32(Console.ReadLine());
        
        Console.WriteLine("ingredients deletar " + deletar);

        //Ingredients novoIngrediente = new IngredientsRepository();
        IIngredientsServices novoIngrediente = new IngredientsServices();


        novoIngrediente.Delete(deletar);*/


        //Listar ingredients geral
        /*Console.WriteLine("Listando todos os ingredientes");

         //IIngredients novoIngrediente = new IngredientsRepository();
         IIngredientsServices novoIngrediente = new IngredientsServices();


         List<Ingredients> dados = new List<Ingredients>();

         dados = novoIngrediente.GetAll();

         for (int i = 0; i < dados.Count; i++)
         {
             Console.WriteLine(dados[i].Id + " " + dados[i].Description);
         }*/


        //Listar ingredients apenas um
        /*Console.WriteLine("Listando apenas um item do ingrediente");

        //IIngredients novoIngrediente = new IngredientsRepository();
         IIngredientsServices novoIngrediente = new IngredientsServices();


         Ingredients dados = new Ingredients();    

         Console.WriteLine("Informe o id do ingrediente");

         int id = Convert.ToInt32(Console.ReadLine());

         dados = novoIngrediente.Get(id);

             Console.WriteLine(dados.Id + " " + dados.Description);*/


        //Alterar ingrediente
        /* Console.WriteLine("Testando o Domain Ingredients");

         Ingredients nova = new Ingredients();

         Console.WriteLine("Alterando um ingrediente");
         Console.WriteLine("Informe o id do ingrediente");
         nova.Id = Convert.ToInt32(Console.ReadLine());

         Console.WriteLine("Informe o novo nome do ingrediente");
         nova.Description = Console.ReadLine();

         Console.WriteLine("Informe a nova quantidade do ingrediente");
         nova.Quantity = Console.ReadLine();

         Console.WriteLine("Informe o id da nova receita");
         nova.IdRecipe = Convert.ToInt32(Console.ReadLine());    

         Console.WriteLine("ingrediente a ser alterado " + nova.Id + " " + nova.Description);

         //IUsers novoUsuario = new UsersRepository();
         IIngredientsServices novoIngrediente= new IngredientsServices();


         novoIngrediente.Update(nova);*/







        //**************************************************************** INICIO DA USERS
        //Cadastra users
        /*Console.WriteLine("Testando o Domain Users");

        Users nova = new Users();

        Console.WriteLine("Cadastrando um usuário");

        Console.WriteLine("Informe o nome do usuário");
        nova.Name = Console.ReadLine();

        Console.WriteLine("Informe o e-mail do usuário");
        nova.Email = Console.ReadLine();

        Console.WriteLine("Informe o telefone do usuário");
        nova.Phone = Console.ReadLine();

        Console.WriteLine("Informe o password do usuário");
        nova.Password = Console.ReadLine();

        Console.WriteLine("Informe o tipo do usuário");
        nova.UserType = UserTypeEnum.user;  


        Console.WriteLine("users cadastrado " + nova.Name);

        //IUsers novaUsuario = new UsersRepository();
        IUsersServices novoUsuario = new UsersServices();


        novoUsuario.Add(nova);*/


        //Deletar Users

        /*Console.WriteLine("Testando o Domain Users");

        Console.WriteLine("Deletando um usuário");
        Console.WriteLine("Informe o número do usuário");

        int deletar = Convert.ToInt32(Console.ReadLine());
        
        Console.WriteLine("users deletar " + deletar);

        //Users novoUsuario = new UsersRepository();
        IUsersServices novoUsuario = new UsersServices();


        novoUsuario.Delete(deletar);*/


        //Listar users geral
        /*Console.WriteLine("Listando todos os usuários");

         //IUsers novoUsuario = new UsersRepository();
         IUsersServices novoUsuario = new UsersServices();


         List<Users> dados = new List<Users>();

         dados = novoUsuario.GetAll();

         for (int i = 0; i < dados.Count; i++)
         {
             Console.WriteLine(dados[i].Id + " " + dados[i].Name + " " + dados[i].Email + " " + dados[i].Phone + " " + dados[i].Password + " " + dados[i].UserType);
         }*/


        //Listar users apenas um
        /*Console.WriteLine("Listando apenas um item do usuário");

       //IUsers novoUsuario = new UsersRepository();
        IUsersServices novoUsuario = new UsersServices();


        Users dados = new Users();    

        Console.WriteLine("Informe o id do usuário");

        int id = Convert.ToInt32(Console.ReadLine());

        dados = novoUsuario.Get(id);

       Console.WriteLine(dados.Id + " " + dados.Name + " " + dados.Email + " " + dados.Phone + " " + dados.Password + " " + dados.UserType);*/



        //Alterar usuario
        /*Console.WriteLine("Testando o Domain Users");

        Users nova = new Users();

        Console.WriteLine("Alterando um usuário");
        
        Console.WriteLine("Informe o id do usuário");
        nova.Id = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Informe o nome do usuário");
        nova.Name = Console.ReadLine();

        Console.WriteLine("Informe o email do usuário");
        nova.Email = Console.ReadLine();

        Console.WriteLine("Informe o telefone do usuário");
        nova.Phone = Console.ReadLine();

        Console.WriteLine("Informe a senha do usuário");
        nova.Password = Console.ReadLine();

        Console.WriteLine("usuário a ser alterado " + nova.Id + " " + nova.Name);

        //IUsers novoUsuario = new UsersRepository();
        IUsersServices novoUsuario = new UsersServices();


        novoUsuario.Update(nova);*/





    }
}

