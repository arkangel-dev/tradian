import React, { useEffect, useState } from "react";
import Footer from "../assets/Footer";
import Header from "../assets/Header";
import axios from "axios";
import Markdown from "react-markdown";
import toast from "react-hot-toast";
import './PostListView.css'
import { SquareUnlock01Icon, Cancel01Icon } from "hugeicons-react";
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
            .get(`https://localhost:7094/Posts?query=${currentSearchQueryStore}&count=${count}`)
            .then((response) => {
                console.log(response.data)
                setData(response.data);
                setLoading(false)
                setDisplayLoadMore(count <= response.data.count)
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
                                    <div className="PostListItem">
                                        <a href={`posts/${item.id}`}><h1>{item.title}</h1></a>
                                        {item.isSecured &&
                                            <p className="post-tag">
                                                <SquareUnlock01Icon />
                                                Secret Membership Post
                                            </p>
                                        }
                                        <p>{item.description}</p>
                                    </div>
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