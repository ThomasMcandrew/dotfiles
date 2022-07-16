syntax on


filetype indent plugin on
syntax enable
set noswapfile
set encoding=UTF-8
inoremap kj <ESC>
set shiftwidth=4
set tabstop=4

call plug#begin()

Plug 'scrooloose/nerdtree', { 'on':  'NERDTreeToggle' }
Plug 'sainnhe/everforest'
Plug 'ryanoasis/vim-devicons'
"Plug 'puremourning/vimspector'
Plug 'prabirshrestha/asyncomplete.vim'
Plug 'prabirshrestha/async.vim'
Plug 'dense-analysis/ale'
Plug 'vim-test/vim-test'
Plug 'junegunn/fzf', { 'do': { -> fzf#install() }}
Plug 'mhinz/vim-startify'
Plug 'ray-x/aurora'
Plug 'rust-lang/rust.vim'
call plug#end()
let g:NERDTreeWinSize = 30
let g:ale_completion_enabled = 1
set guifont=FiraCode\ NF:h16


nnoremap <C-J> <C-W><C-J>
nnoremap <C-K> <C-W><C-K>
nnoremap <C-L> <C-W><C-L>
nnoremap <C-H> <C-W><C-H>
nnoremap <C-o> :NERDTreeToggle<CR>
nnoremap ff :FZF<CR>
nnoremap <C-b> :bprevious<CR>
nnoremap <C-n> :bnext<CR>

let g:ale_linters = {
\   'rust': ['analyzer']
\}
let g:ale_fixers = { 'rust': ['rustfmt', 'trim_whitespace', 'remove_trailing_lines'] }

"startify

let g:startify_lists = [
        \ { 'type': 'sessions',  'header': ['   Sessions']       },
        \ { 'type': 'files',     'header': ['   MRU']            },
        \ { 'type': 'bookmarks', 'header': ['   Bookmarks']      },
        \ { 'type': 'commands',  'header': ['   Commands']       },
        \ ]
		
"end startify

"colorscheme everforest
set termguicolors            " 24 bit color
colorscheme aurora
