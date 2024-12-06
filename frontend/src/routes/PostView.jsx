import React, { useEffect, useState } from "react";
import { useParams } from "react-router-dom";
import Footer from "../assets/Footer";
import Header from "../assets/Header";
import axios from "axios";
import Markdown from "react-markdown";
import './PostView.css'

export default function PostView() {

    const { postid } = useParams();
    const [loading, setLoading] = useState(true);
    const [data, setData] = useState(null);
    const [errorMessage, setErrorMessage] = useState(false);

    useEffect(() => {
        axios
            .get(`https://localhost:7094/Posts/${postid}`)
            .then((response) => {
                console.log(response.data)
                setData(response.data);
                setLoading(false)
            });
    }, [])


    useEffect(() => {
        document.title = data?.title ?? "Loading"
    }, [data])

    return (
        <>
        
            <div className="postContainer">
                {!loading &&
                    <>
                        <h1 className="PostTitle">{data.title}</h1>
                        <div className="PostContent">
                            <Markdown>{data.body}</Markdown>
                        </div>
                    </>
                }
            </div>
        </>
    );
}