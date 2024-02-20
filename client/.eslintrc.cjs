/* eslint-env node */
require('@rushstack/eslint-patch/modern-module-resolution');

module.exports = {
   root: true,
   extends: [
      'plugin:vue/vue3-strongly-recommended',
      'eslint:recommended',
      '@vue/eslint-config-typescript',
      '@vue/eslint-config-prettier/skip-formatting',
      '@vue/typescript/recommended'
   ],
   rules: {
      'vue/max-len': [
         'error',
         {
            code: 150,
            template: 150,
            tabWidth: 3,
            comments: 150,
            ignorePattern: '',
            ignoreComments: false,
            ignoreTrailingComments: false,
            ignoreUrls: false,
            ignoreStrings: false,
            ignoreTemplateLiterals: false,
            ignoreRegExpLiterals: false,
            ignoreHTMLAttributeValues: false,
            ignoreHTMLTextContents: false
         }
      ],
      semi: ['error', 'always'],
      'vue/html-end-tags': ['error'],
      'vue/multi-word-component-names': [
         'error',
         {
            ignores: ['index']
         }
      ],
      'vue/no-multi-spaces': [
         'error',
         {
            ignoreProperties: false
         }
      ],
      'vue/no-spaces-around-equal-signs-in-attribute': ['error'],
      'vue/no-undef-properties': [
         'error',
         {
            ignores: ['/^\\$/']
         }
      ],
      'vue/eqeqeq': ['error', 'always']
   },
   parser: 'vue-eslint-parser',
   parserOptions: {
      ecmaVersion: 'latest',
      parser: '@typescript-eslint/parser',
      sourceType: 'module'
   }
};
