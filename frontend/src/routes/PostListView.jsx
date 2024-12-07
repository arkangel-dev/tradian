import React, { useEffect, useState } from "react";
import Footer from "../assets/Footer";
import Header from "../assets/Header";
import axios from "axios";
import Markdown from "react-markdown";
import toast from "react-hot-toast";
import './PostListView.css'
import { SquareUnlock01Icon, Cancel01Icon, ArrowUpRight01Icon } from "hugeicons-react";
import ScrollInFromSide from "../components/ScrollInFromSide"

export default function PostView() {

    const [loading, setLoading] = useState(true);
    const [data, setData] = useState(null);
    const [errorMessage, setErrorMessage] = useState(false);
    const [searchQuery, setSearchQuery] = useState('')
    const [timer, setTimer] = useState(null);
    const [displayLoadMore, setDisplayLoadMore] = useState(false)

    useEffect(() => {
        document.title = "Tradian Posts"
        performSearch()
    }, [])


    let currentSearchQueryStore = ''
    const handleInputChange = (value) => {
        setSearchQuery(value);
        if (timer) {
            clearTimeout(timer)
        }

        setTimer(setTimeout(performSearch, 500));
        currentSearchQueryStore = value;
    }

    const [count, setCount] = useState(3);

    const loadMore = () => {
        setCount(count + 3)
    }

    const performSearch = () => {
        axios
            .get(`/api/posts?query=${currentSearchQueryStore}&count=${count}`)
            .then((response) => {
                setData(response.data);
                setLoading(false)
                setDisplayLoadMore(count <= response.data.count)
            })
            .catch((error) => {
                toast.error("Failed to fetch posts")
            });
    }

    useEffect(performSearch, [count])

    return (
        <>
            <div className="r-container PostListRoot">
                <div className="searchBox">
                    <input
                        value={searchQuery}
                        onChange={(e) => handleInputChange(e.target.value)}
                        type="text" placeholder="Search for a post" />
                    <button onClick={() => handleInputChange('')}>
                        <Cancel01Icon size={"1.25rem"} />
                    </button>
                </div>
                <div className="PostListContainer">
                    {!loading &&
                        <>
                            {data.results.map((item) => (
                                <ScrollInFromSide key={item.id}>
                                    <a href={`posts/${item.id}`}>
                                        <div className="PostListItem">
                                            <h1>{item.title}</h1>
                                            {item.isSecured &&
                                                <p className="post-tag">
                                                    <SquareUnlock01Icon />
                                                    Secret Membership Post
                                                </p>
                                            }
                                            <p>{item.description}</p>
                                            <div className="flex-1"></div>
                                            <p className="flex gap-2"><span className="underline underline-offset-1">Read the post</span><ArrowUpRight01Icon/></p>
                                        </div>
                                    </a>
                                </ScrollInFromSide>
                            ))}
                        </>
                    }
                </div>
                {displayLoadMore &&
                    <button onClick={loadMore}>Load More</button>
                }
            </div>
        </>
    );
}