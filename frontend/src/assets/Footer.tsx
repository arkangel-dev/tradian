import "./Footer.css"
import { Facebook02Icon, InstagramIcon, TwitterIcon } from "hugeicons-react"

import animationData from './tradian-logo-light.json'
import Lottie from 'react-lottie'
import { useEffect, useState } from "react"
import axios from "axios"

function Footer() {
    const [data, setData] = useState(null);
    const [loading, setLoading] = useState(false);
    

    useEffect(() => {
        axios
        .get('https://localhost:7094/Footer')
        .then((response) => setData(response.data))
        .finally(() => setLoading(true));
    })

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
            <div className="footer">
                <div className="footer-container">
                    <div className="subscribe">
                        <div className="subscribe-title">
                            <h1>Subscribe to our newsletter</h1>
                            <h2>Receive the Latest Updates, News, and Insights from Tradian</h2>
                        </div>
                        <div className="enter-email">
                            <input placeholder="Enter your email" />
                            <button>Subscribe now</button>
                        </div>
                    </div>
                    <div className="link-row">
                        <div className="link-list-container">
                            
                            {/* <ul className="link-list">
                                <li>Quick Links</li>
                                <li>oneGov</li>
                                <li>Tradenet</li>
                            </ul>

                            <ul className="link-list">
                                <li>Logistics</li>
                                <li>Vessels</li>
                                <li>Shipping Agents</li>
                                <li>Freight Forwarders</li>
                                <li>Courier Agents</li>
                                <li>Brokers</li>
                            </ul>

                            <ul className="link-list">
                                <li>Terms and Policies</li>
                                <li>Terms and Conditions</li>
                            </ul> */}
                        </div>

                        <div>
                            <img src="./bml.5aEfgva9.png" />
                        </div>
                    </div>
                    <div className="logo-social">
                        <div>
                            <Lottie options={defaultOptions}
                                width={150}
                                isStopped={true}
                                isPaused={true} />
                        </div>
                        <ul>
                            <li><Facebook02Icon /></li>
                            <li><InstagramIcon /></li>
                            <li><TwitterIcon /></li>
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