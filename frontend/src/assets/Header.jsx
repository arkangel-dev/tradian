import './Header.css'
import Lottie from 'react-lottie'
import animationData from './tradian-logo-dark.json'

function Header() {
    const defaultOptions = {
        loop: false,
        autoplay: true,
        animationData: animationData,
        rendererSettings: {
            preserveAspectRatio: 'xMidYMid slice'
        }
    };

    return (
        <div className="r-container navcontainer">
            <div className='navbar'>
                <div className="logo">
                    <Lottie options={defaultOptions}
                        width={150}
                        isStopped={true}
                        isPaused={true} />
                </div>
                <div className="buttons">
                    <a>Business</a>
                    <a>Individual</a>
                    <a>Support</a>
                    <a>Super Secrets</a>
                </div>
                <div className="login">
                    <button>Login</button>
                </div>
            </div>
        </div>
    )
}

export default Header