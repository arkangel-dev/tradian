import styles from './StatusViews.module.css'
import { Loading01Icon, SquareLock02Icon, DeadIcon, FileNotFoundIcon } from 'hugeicons-react';

export function NotFound() {
    return (
        <div className={styles.NotFound}>
            <FileNotFoundIcon size={"3.5rem"} />
            <h1>Not Found</h1>
            <p>The page you're looking could not be found</p>
        </div>
    );
}

export function Loading() {
    return (
        <div className={styles.NotFound}>
            <Loading01Icon size={"3.5rem"} />
            <h1>Loading</h1>
        </div>
    );
}

export function BackendIssue() {
    return (
        <div className={styles.NotFound}>
            <DeadIcon size={"3.5rem"} />
            <h1>Something went wrong</h1>
            <p>The application backend cannot be reached</p>
        </div>
    );
}

export function AccessDenied() {
    return (
        <div className={styles.NotFound}>
            <SquareLock02Icon size={"3.5rem"} />
            <h1>Access Denied</h1>
            <p>You need to be a member and logged in to view this content</p>
        </div>
    );
}