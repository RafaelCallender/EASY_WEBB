#!/usr/bin/env bash
set -euo pipefail

script_dir="$(cd -- "$(dirname -- "${BASH_SOURCE[0]}")" && pwd)"

if [[ "$(uname -s)" != "Linux" || "$(uname -m)" != "x86_64" ]]; then
    echo "This build script supports Linux x86_64 only." >&2
    exit 1
fi

for tool in cmake git c++; do
    if ! command -v "$tool" >/dev/null 2>&1; then
        echo "Required build tool not found: $tool" >&2
        exit 1
    fi
done

build_dir="$script_dir/obj/native-backend"
install_dir="$script_dir/native/linux-x64"
cmake_args=(
    -DCMAKE_BUILD_TYPE=Release
    "-DCMAKE_INSTALL_PREFIX=$install_dir"
    -DCMAKE_INSTALL_LIBDIR=.
    "-DCMAKE_C_FLAGS=-mno-avx -mno-avx2 -mno-avx512f -mno-fma -mno-f16c -mno-bmi2"
    "-DCMAKE_CXX_FLAGS=-mno-avx -mno-avx2 -mno-avx512f -mno-fma -mno-f16c -mno-bmi2"
)

if [[ -n "${LLAMA_CPP_SOURCE_DIR:-}" ]]; then
    cmake_args+=("-DFETCHCONTENT_SOURCE_DIR_LLAMA_CPP=$LLAMA_CPP_SOURCE_DIR")
fi

cmake -S "$script_dir/native" -B "$build_dir" "${cmake_args[@]}"
cmake --build "$build_dir" --target llama --parallel "${CMAKE_BUILD_PARALLEL_LEVEL:-2}"
cmake --install "$build_dir"

echo "Custom no-AVX backend installed in $install_dir"
