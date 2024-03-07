
function Header() {
    return (
        <>            
            <nav className="navbar navbar-dark bg-dark navbar-expand-lg" aria-label="Eleventh navbar example">
                <div className="container-fluid">
                    <a className="navbar-brand" href="/">Roteirizador</a>
                    <button className="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarsExample09"
                        aria-controls="navbarsExample09" aria-expanded="false" aria-label="Toggle navigation">
                        <span className="navbar-toggler-icon"></span>
                    </button>

                    <div className="collapse navbar-collapse" id="navbarsExample09">
                        <ul className="navbar-nav me-auto mb-2 mb-lg-0">
                            <li className="nav-item">
                                <a className="nav-link active" aria-current="page" href="/">Home</a>
                            </li>
                            <li className="nav-item">
                                <a className="nav-link" aria-current="page" href="rota">Rotas</a>
                            </li>
                        </ul>
                    </div>
                </div>
            </nav>
            <div className="position-absolute top-0 end-0">     
        </div >
        </>
    )
}

export default Header
