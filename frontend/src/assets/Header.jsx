import './Header.css'
import Lottie from 'react-lottie'
import animationData from './tradian-logo-dark.json'
import toast from 'react-hot-toast';

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
                    <button onClick={() => toast.error("Im working on it!")}>Login</button>
                </div>
            </div>
        </div>
    )
}

export default Header