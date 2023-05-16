<?php
    include 'connect.php';
    session_start();

    $nome = $_SESSION['nome'];
    $senha = $_SESSION['senha'];

            $x = 0;
            $sql2 = "SELECT * FROM sala;";
            $resultado2 = mysqli_query($con,$sql2) or die(mysql_error()."<br>Erro ao executar a inserção dos dados");
            if (mysqli_num_rows($resultado2)!=0){
                while($elemento = mysqli_fetch_array($resultado2)){
                    $nomeSala[$x] = $elemento['nomeSala'];
                    $criadorSala[$x] = $elemento['criadorSala'];
                    $x += 1;
                }
            }
            $salas = "";
            for($y=0; $y<$x; $y++){
                if($criadorSala[$y] == $nome){
                    $salas .= '<form method="post">
                                    <div class="card text-center">
                                    <h5 class="card-header"><u>'.$nomeSala[$y].'</u> <span class="badge text-bg-warning">ADM</span></h5>
                                    <div class="card-body">
                                        <h5 class="card-title">Administrador:'.$criadorSala[$y].'</h5>
                                    </div>
                                    </div>
                                </form>
                                ';
                }
            }
            for($y=0; $y<$x; $y++){
                if($criadorSala[$y] != $nome){
                    $salas .= '<form method="post">
                                    <div class="card text-center">
                                    <h5 class="card-header"><u>'.$nomeSala[$y].'</u></h5>
                                    <div class="card-body">
                                        <h5 class="card-title">Administrador:'.$criadorSala[$y].'<br></h5>
                                    </div>
                                    </div>
                                </form>
                                ';
            }
        }

        if($x < 1){
            $salas = "<h1>Nenhuma sala foi criada.</h1>";
        }


                ?>
                <html>
                    <head>
                        <title>Salas</title>
                        <meta charset="utf-8">
                        <meta name="viewport" content="width=device-width, initial-scale=1">
                        <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.2.2/dist/css/bootstrap.min.css" rel="stylesheet">
                        <link href="https://getbootstrap.com/docs/5.2/assets/css/docs.css" rel="stylesheet">
                        <style>
                            body{
                                padding-left: 200px;
                                padding-right: 200px;
                                padding-top: 50px;
                                padding-bottom: 50px;
                            }
                            .cards{
                                padding-top: 20px;
                            }
                        </style>
                    </head>
                    <body>
                    voce esta logado como: <?php echo $nome; ?>, <a href="../login/LoginUsuario.html">Sair</a> <br>
                            <a href="../homepage.html">Voltar</a>
                        <div class="cards">
                            <?php echo $salas;?>
                        </div>
                    </body>
                </html>

        