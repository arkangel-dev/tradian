import './Button.css'

function Button({title, onClick}) {
    return (
        <button className='c-button' onClick={onClick}>{title}</button>
    )
}

export default Button