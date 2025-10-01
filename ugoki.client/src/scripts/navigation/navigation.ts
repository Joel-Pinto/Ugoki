import { useRouter } from 'vue-router';

export class Navigation
{
    currentPage: string;

    constructor(page: string)
    {
        this.currentPage = page;
    }

    navigateTo(page: string, options?: Record<string, string>): void
    {
        if(this.isActive(page)) return;

        const router = useRouter();
        
        if(options === undefined)
            router.push({ name: page });
        else
            router.push({ name: page, params: options });

        this.currentPage = page;
    }

    isActive(page: string): boolean
    {
        return this.currentPage === page;
    }
}
