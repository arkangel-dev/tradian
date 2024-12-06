import { StrictMode } from 'react'
import ReactDOM from "react-dom";
import './index.css'
import { createRoot } from 'react-dom/client';

import Home from './routes/Home.jsx'
import Secrets from './routes/Secrets.jsx';
import PostView from './routes/PostView.jsx'
import PostListView from './routes/PostListView.jsx'

import { BrowserRouter, Routes, Route } from "react-router-dom";
import Header from './assets/Header.jsx';
import Footer from './assets/Footer.jsx';
import { Toaster } from 'react-hot-toast';
export default function App() {

    return (
        <>
        <Toaster />
        <Header/>
            <StrictMode>
            <BrowserRouter>
                <Routes>
                    <Route path="/" element={<Home />}/>
                    <Route path='secrets' element={<Secrets/>}/>
                    <Route path='posts/:postid' element={<PostView/>}/>
                    <Route path='posts' element={<PostListView/>}/>
                </Routes>
            </BrowserRouter>
        </StrictMode>
        <Footer/>
        </>
    
    )
}

const root = createRoot(document.getElementById('root'));
root.render(<App />);