import './Header.css'
import Lottie from 'react-lottie'
import animationData from './tradian-logo-dark.json'
import toast from 'react-hot-toast';
import { ArrowDown01Icon } from 'hugeicons-react';
import ReactModal from 'react-modal';
import { useState } from 'react';
import LoginModal from '../components/LoginModal';
import { useEffect } from 'react';
import axios from 'axios';

function Header() {
    const [modalIsOpen, setIsOpen] = useState(false);
    const [amILoggedIn, setAmILoggedIn] = useState(false);
    const defaultOptions = {
        loop: false,
        autoplay: true,
        animationData: animationData,
        rendererSettings: {
            preserveAspectRatio: 'xMidYMid slice'
        }
    };


    useEffect(() => {
        axios.get("/api/authentication/amiloggedin")
            .then((r) => {
                setAmILoggedIn(true);
            })
            .catch((e) => {
                setAmILoggedIn(false);
            })
    }, [])

    const openLoginModal = () => {
        setIsOpen(true);
    }

    const closeLoginModal = () => {
        location.reload();
        setIsOpen(false);
    }

    const logout = () => {
        document.cookie = "AuthToken=; expires=Thu, 01 Jan 1970 00:00:00 UTC; path=/;";
        location.reload();
    }

    return (
        <>
            <div className="r-container navcontainer">
                <div className='navbar'>
                    <div className="logo">
                        <a href='/'>
                            <Lottie options={defaultOptions}
                                width={150}
                                isStopped={true}
                                isPaused={true} />
                        </a>
                    </div>
                    <div className="buttons">
                        <a onClick={() => toast.error("This leads to nowhere")}>Business</a>
                        <a href='./Posts'>Posts</a>
                        <a onClick={() => toast.error("No support!")}>Support</a>
                    </div>
                    <div className="login">
                        {
                            !amILoggedIn ?
                                <button onClick={openLoginModal}>Login</button> :
                                <button onClick={logout}>Logout</button>
                        }
                    </div>
                </div>
            </div>
            <ReactModal isOpen={modalIsOpen} onRequestClose={closeLoginModal} >
                <LoginModal onSuccessfulLogin={closeLoginModal} />
            </ReactModal>
        </>
    )
}

export default Header