import "./Footer.css"
import { Facebook02Icon, InstagramIcon, TwitterIcon } from "hugeicons-react"

import toast from 'react-hot-toast';
import animationData from './tradian-logo-light.json'
import Lottie from 'react-lottie'
import { useEffect, useState } from "react"
import axios from "axios"

function Footer() {
    const [data, setData] = useState(null);
    const [loading, setLoading] = useState(true);


    useEffect(() => {
        axios
            .get('https://localhost:7094/Footer')
            .then((response) => {
                setData(response.data);
                setLoading(false)
            });
    }, [])

    const defaultOptions = {
        loop: false,
        autoplay: true,
        animationData: animationData,
        rendererSettings: {
            preserveAspectRatio: 'xMidYMid slice'
        }
    };

    return (
        <>
            <div className="space-gen"></div>
            <div className="footer">
                <div className="footer-container">
                    <div className="subscribe">
                        <div className="subscribe-title">
                            <h1>Subscribe to our newsletter</h1>
                            <h2>Receive the Latest Updates, News, and Insights from Tradian</h2>
                        </div>
                        <div className="enter-email">
                            <input placeholder="Enter your email" />
                            <button onClick={() => toast.error("Not implemented yet either!")}>Subscribe now</button>
                        </div>
                    </div>
                    <div className="link-row">
                        <div className="link-list-container">
                            {!loading &&
                                <>
                                    {data.map((item) => (
                                        <ul key={item.id} className="link-list">
                                            <li>{item.section}</li>

                                            {item.links.map((link) => (
                                                <li key={link.id} >
                                                    <a href={link.link}>{link.value}</a>
                                                </li>
                                            ))}

                                        </ul>
                                    ))}
                                </>
                            }
                        </div>

                        <div>
                            <img src="./bml.5aEfgva9.png" />
                        </div>
                    </div>
                    <div className="logo-social">
                        <div>
                            <a href="/">
                                <Lottie options={defaultOptions}
                                    width={150}
                                    isStopped={true}
                                    isPaused={true} />
                            </a>
                        </div>
                        <ul>
                            <a href="https://facebook.com"><Facebook02Icon /></a>
                            <a href="https://instagram.com"><InstagramIcon /></a>
                            <a href="https://bsky.app/"><TwitterIcon /></a>
                        </ul>
                    </div>
                    <div className="line"></div>
                    <div className="credits">
                        <p>Operated by Tradenet</p>
                        <p>© 2024, Government of Maldives. All Rights Reserved.</p>
                    </div>
                </div>
            </div>
        </>
    )
}

export default Footer