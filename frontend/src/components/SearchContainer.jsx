import { useState } from 'react';
import { InboxDownloadIcon, Location05Icon } from 'hugeicons-react';
import Button from '../assets/Button.jsx';
import './SearchContainer.css';

function SearchContainer() {
    const [isCheckDeclarationMode, setIsCheckDeclarationMode] = useState(true);
    const [cNumber, setCNumber] = useState('');
    const [rNumber, setRNumber] = useState('');
    const [containerId, setContainerId] = useState('')

    const switchToDeclarationMode = () =>
        setIsCheckDeclarationMode(true);


    const switchToContainerTracking = () =>
        setIsCheckDeclarationMode(false);

    const view = isCheckDeclarationMode ? (
        <>
            <div className="w-full">
                <h2>Declaration Status</h2>
                <p>Check import and export declaration status</p>
            </div>
            <div className="input-row">
                <div className="input-label">
                    <span>C Number</span>
                    <input
                        value={cNumber}
                        onChange={(e) => setCNumber(e.target.value)}
                        placeholder="C1234" />
                </div>
                <div className="input-label">
                    <span>R Number</span>
                    <input
                        value={rNumber}
                        onChange={(e) => setRNumber(e.target.value)}
                        placeholder="R/1234/00MP" />
                </div>
                <Button title="Search" />
            </div>
        </>
    ) : (
        <>
            <div className="w-full">
                <h2>Container Tracking</h2>
                <p>Retrieve Container status and ETA</p>
            </div>
            <div className="input-row">
                <div className="input-label">
                    <span>Container ID</span>
                    <input
                        value={containerId}
                        onChange={(e) => setContainerId(e.target.value)}
                        placeholder="Container ID" />
                </div>
                <Button title="Track" />
            </div>
        </>
    );

    return (
        <div className="quickLookup mt-20">
            <div className="button-toggle ">
                <button
                    onClick={switchToDeclarationMode}
                    className={isCheckDeclarationMode ? 'active' : ''}
                >
                    <InboxDownloadIcon />
                    Check Declaration
                </button>
                <button
                    onClick={switchToContainerTracking}
                    className={isCheckDeclarationMode ? '' : 'active'}
                >
                    <Location05Icon />
                    Container Tracking
                </button>
            </div>

            <div className="input-area">
                {view}
            </div>
        </div>
    );
}

export default SearchContainer;
