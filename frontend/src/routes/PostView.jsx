import React, { useEffect, useState } from "react";
import { useParams } from "react-router-dom";
import axios from "axios";
import Markdown from "react-markdown";
import { NotFound, BackendIssue, AccessDenied, Loading } from "../components/StatusViews.jsx"
import './PostView.css'

export default function PostView() {

    const { postid } = useParams();
    const [loading, setLoading] = useState(true);
    const [data, setData] = useState(null);
    const [renderSegment, setRenderSegment] = useState(<Loading />);

    useEffect(() => {
        axios
            .get(`/api/posts/${postid}`)
            .then((response) => {
                setData(response.data);
                setLoading(false)
                setRenderSegment(

                    <div className="postContainer">
                        <h1 className="PostTitle">{response.data.title}</h1>
                        <div className="PostContent">
                            <Markdown>{response.data.body}</Markdown>
                        </div>
                    </div>
                )
                console.log("Rendering complete")
            })
            .catch((e) => {
                console.error({
                    errorFound: e
                })

                switch (e.code) {
                    case "ERR_NETWORK":
                        setRenderSegment(<BackendIssue />)
                        break;

                    default:
                        switch (e.status) {
                            case 404:
                                setRenderSegment(<NotFound />)
                                break;

                            case 401:
                                setRenderSegment(<AccessDenied />)
                                break;
                        }
                }

            });
    }, [])


    useEffect(() => {
        console.log(renderSegment)
    }, [renderSegment])

    useEffect(() => {
        document.title = data?.title ?? "Loading"
    }, [data])

    return (
        <>
            {renderSegment}
        </>
    );
}