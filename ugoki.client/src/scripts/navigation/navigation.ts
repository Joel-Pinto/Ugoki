import { useRouter } from 'vue-router';

export function useNavigation(initialPage: string) {
  const router = useRouter();
  let currentPage = initialPage;

  function navigateTo(page: string, options?: Record<string, string>) {
    if (isActive(page)) return;

    if (!options)
      router.push({ name: page });
    else
      router.push({ name: page, params: options });

    currentPage = page;
  }

  function isActive(page: string) {
    return currentPage === page;
  }

  return { navigateTo, isActive };
}
