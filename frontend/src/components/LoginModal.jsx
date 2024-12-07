import axios from "axios";
import { useState } from "react"
import toast from "react-hot-toast"

export default function LoginModal({ onSuccessfulLogin }) {
    const [username, setUsername] = useState('');
    const [password, setPassword] = useState('');


    const onLogin = async () => {
        try {
            const result = await axios.post(
                "/api/authentication/login",
                { username: username, password: password },
                {
                    withCredentials: true
                }
            );
            toast.success("Login Successful!");
            onSuccessfulLogin();

        } catch (error) {
            toast.error("Login failed!")
        }
    };

    return (
        <div className='flex flex-col gap-4 px-5 py-4'>
            <div className='flex flex-col gap-2 items-center'>
                <h1 className='text-3xl text-gray-800 font-semibold'>Login</h1>
                <p className='w-3/4 text-sm mt-0 text-center text-gray-500'>Enter your login to get access to the secrets, whatever they may be</p>
            </div>
            <div className="input-label">
                <span>Username</span>
                <input
                    value={username}
                    onChange={(e) => setUsername(e.target.value)}
                    className='border rounded-full border-gray-300'
                    placeholder="Enter your username" />
            </div>

            <div className="input-label">
                <span>Password</span>
                <input
                    value={password}
                    onChange={(e) => setPassword(e.target.value)}
                    type='password'
                    className='border rounded-full border-gray-300'
                    placeholder="Enter your password" />
            </div>

            <button onClick={onLogin} className='mt-4 bg-red-700 text-white py-2 rounded-md'>Login</button>
        </div>
    )
}