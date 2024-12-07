import { StrictMode } from 'react'
import ReactDOM from "react-dom";
import './index.css'
import { createRoot } from 'react-dom/client';

import Home from './routes/home.jsx';
import Secrets from './routes/Secrets.jsx';

import PostView from './routes/Posts/PostView.jsx';
import PostListView from './routes/posts/PostListView.jsx'

import NewsListView from './routes/news/NewsListView.jsx'
import NewsView from './routes/news/NewsView.jsx'

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
                    
                    <Route path='news/:newsid' element={<NewsView/>}/>
                    <Route path='news' element={<NewsListView/>}/>
                </Routes>
            </BrowserRouter>
        </StrictMode>
        <Footer/>
        </>
    
    )
}

const root = createRoot(document.getElementById('root'));
root.render(<App />);