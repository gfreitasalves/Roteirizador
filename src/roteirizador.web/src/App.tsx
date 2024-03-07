import './App.css'
import { BrowserRouter, Route, Routes } from 'react-router-dom'
import Header from './components/layout/Header'
import Home from './pages/Home'
import ListagemRota from './pages/rota/ListagemRota'
import NovaRota from './pages/rota/NovaRota'
import EditarRota from './pages/rota/EditarRota'

function App() {
    return (
        <>
            <BrowserRouter>
                <Header></Header>
                <div className="container mt-5">

                    <Routes>
                        <Route path="/" element={<Home />} />
                        <Route path="/rota" element={<ListagemRota />} />
                        <Route path="/rota/nova" element={<NovaRota />} />
                        <Route path="/rota/:id" element={<EditarRota />} />
                    </Routes>
                </div>
            </BrowserRouter>
        </>
    )
}

export default App
